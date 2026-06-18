# SystemBase

El objetivo es crear una plantilla base para un sistema backend que permita desarrollar APIs robustas, escalables y de
fácil consumo desde cualquier plataforma (web, móvil, desktop). Esto optimizará y estandarizará el proceso de
desarrollo.

---

## Arquitectura

| Capa              | Descripción                                                                                                                                                                                      |
|-------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Authorization** | Define las reglas de control de acceso mediante el atributo `[RequirePermission("nombrePermiso")]`, que restringe el acceso a los endpoints según los permisos asignados al usuario autenticado. |
| **Controllers**   | Define los controladores y los endpoints de la API REST. Cada controlador agrupa las rutas relacionadas a un recurso y delega la lógica a la capa de servicios.                                  |
| **Data**          | Contiene `ApplicationDBContext.cs`, que configura mediante Entity Framework (EF) la estructura, relaciones y seed data de la base de datos.                                                      |
| **Logs**          | Configuración de Serilog para el monitoreo del sistema. Registra alertas, advertencias y errores en tiempo de ejecución.                                                                         |
| **Mappers**       | Contiene la lógica de conversión entre entidades del dominio y modelos DTO, manteniendo separadas las capas de datos y presentación.                                                             |
| **Migrations**    | Historial de migraciones generadas por EF que reflejan los cambios estructurales aplicados a la base de datos a lo largo del tiempo.                                                             |
| **Models**        | Contiene los modelos globales del sistema, incluyendo los DTOs (transferencia de datos) y los Snapshots utilizados en la lógica de negocio.                                                      |
| **Repositorio**   | Capa de acceso a datos. Define las interfaces (`IRepositorio`) y sus implementaciones para encapsular las consultas y operaciones sobre la base de datos.                                        |
| **Services**      | Contiene la lógica de negocio del sistema. Define las interfaces (`IServices`) y sus implementaciones que coordinan las operaciones entre controladores y repositorios.                          |

---

## Sistema de autenticación

El sistema usa **JWT con firma RSA-SHA256** (clave asimétrica). El flujo completo es:

```
POST /Auth          → Login         → Access Token (15 min) + RefreshToken cookie (HttpOnly)
POST /Auth/refresh  → Renovar       → Nuevo Access Token + nuevo RefreshToken (rotación)
POST /Auth/Logout   → Cerrar sesión → Invalida el RefreshToken activo
```

### Tokens

| Token              | Duración                                                                                           | Transporte                                                |
|--------------------|----------------------------------------------------------------------------------------------------|-----------------------------------------------------------|
| Access Token (JWT) | 15 minutos (configurable en `Jwt:AccessTokenMinutes`)                                              | Header `Authorization: Bearer <token>`                    |
| Refresh Token      | N días (configurable en `Jwt:RefreshTokenDays`), expira a medianoche del día en curso por política | Cookie `HttpOnly`, `Path=/Auth`, ligado a IP y User-Agent |

**Restricciones de seguridad:**

- Máximo **3 sesiones activas** por usuario. Al hacer login con una 4.ª sesión se invalida la más antigua.
- El Refresh Token se almacena en base de datos como hash **HMAC-SHA256**.
- Al renovar, se valida que la IP y el User-Agent coincidan. Si no coinciden, se invalidan **todos** los tokens del
  usuario.
- Las contraseñas se almacenan con **Argon2**.

### Respuesta de los endpoints de autenticación

Tanto `POST /Auth` como `POST /Auth/refresh` retornan el mismo cuerpo JSON:

```json
{
  "token": "eyJhbGci...",
  "expiresAt": "2026-05-11T14:30:00+00:00"
}
```

| Campo       | Tipo                      | Descripción                                                                                                                 |
|-------------|---------------------------|-----------------------------------------------------------------------------------------------------------------------------|
| `token`     | string                    | Access Token JWT firmado con RSA-SHA256. Válido por 15 minutos. Debe enviarse en el header `Authorization: Bearer <token>`. |
| `expiresAt` | DateTimeOffset (ISO 8601) | Fecha y hora exacta de expiración del Access Token. Útil para hacer refresh proactivo antes de que expire.                  |

El resto de la información del usuario (nombre, apellidos, permisos, estado) está disponible directamente en los claims
del JWT, decodificando el payload sin necesidad de un endpoint adicional.

### Claims del JWT

El Access Token incluye los siguientes claims:

| Claim         | Descripción                                                    |
|---------------|----------------------------------------------------------------|
| `sub`         | ID del usuario                                                 |
| `unique_name` | Nombre de usuario                                              |
| `name`        | Nombre completo                                                |
| `app`         | Apellido paterno                                               |
| `apm`         | Apellido materno                                               |
| `status`      | Estado del usuario (`"true"` / `"false"`)                      |
| `perm`        | Diccionario JSON de permisos por scope (ver sección siguiente) |
| `exp`         | Timestamp Unix de expiración (estándar JWT)                    |

---

## Sistema de permisos y X-Active-Scope

### Concepto

Un usuario puede tener múltiples **asignaciones** (`UserAssignments`). Cada asignación vincula al usuario con un **rol**
dentro de un **scope** (contexto), por ejemplo: ser CEO de la empresa o Gerente de un área específica.

Al hacer login, todos los permisos de todas las asignaciones activas del usuario se empaquetan en el claim `perm` del
JWT, agrupados por scope:

```json
{
  "COMPANY:1":      ["auth.logout.*", "auth.access.*", "users.read.*"],
  "COMPANY_AREA:3": ["auth.logout.self"]
}
```

La clave del diccionario es `{scopeType}:{userAssignmentId}`.

### Tipos de scope (`scopeType`)

| Valor                   | Descripción                                            |
|-------------------------|--------------------------------------------------------|
| `COMPANY`               | Contexto de empresa completa                           |
| `COMPANY_AREA`          | Contexto de un área dentro de la empresa               |
| `COMPANY_AREA_WORKDATE` | Contexto de un área en una fecha de trabajo específica |

### Header X-Active-Scope

En cada request a un endpoint protegido, el cliente debe enviar el header:

```
X-Active-Scope: COMPANY:1
```

Este header le indica al sistema **en qué contexto está operando** el usuario para esa petición. El
`PermissionAuthorizationHandler` usa ese valor como clave para extraer el subconjunto de permisos del claim `perm` y
validarlos contra el permiso requerido por el endpoint.

### Flujo de validación

```
Request
  │
  ├─ ¿Tiene header X-Active-Scope?          → No → 403
  ├─ ¿JWT contiene claim "perm"?             → No → 403
  ├─ ¿El scope está en el diccionario perm?  → No → 403
  └─ ¿Algún permiso del scope satisface
       [RequirePermission("...")]?            → No → 403
                                              → Sí → ✓ Acceso permitido
```

### Wildcard en permisos

Los permisos soportan comodín `*` por segmento. Un permiso asignado como `auth.logout.*` satisface cualquier permiso
requerido de la forma `auth.logout.{lo-que-sea}`, por ejemplo `auth.logout.self` o `auth.logout.subordinate`.

La lógica es **OR**: basta con que **cualquiera** de los permisos del scope activo satisfaga el permiso requerido.

### Acceso a los permisos que otorgaron el acceso (`MatchedPermissions`)

Cuando `PermissionAuthorizationHandler` autoriza la request, además de llamar a `context.Succeed(...)` guarda en
`HttpContext.Items["MatchedPermissions"]` la lista de **todos** los permisos del scope activo que satisficieron el
`[RequirePermission(...)]` (no solo el primero), porque un usuario puede tener varios roles que otorgan distintos
niveles de acceso al mismo tiempo (ej. `self` y `subordinate` simultáneamente).

El controller puede leer ese valor sin volver a parsear el JWT ni reimplementar la lógica de wildcard:

```csharp
var matched = HttpContext.Items["MatchedPermissions"] as List<string> ?? [];

var scope = matched.Any(p => p.EndsWith(".*")) ? "all"
    : matched.Any(p => p.EndsWith(".subordinate")) ? "subordinate"
    : "self";
```

> La precedencia (`* > subordinate > self`) se decide explícitamente en el controller — no depender del orden de la
> lista, ya que no está garantizado.

### Uso en endpoints

```csharp
[RequirePermission("auth.logout.self")]
[HttpPost("Logout")]
public async Task<IActionResult> Logout() { ... }
```

### Cadena de resolución de permisos

```
UserAssignments
  └─ idRole → Roles
                └─ idNameRule → NameRule
                                  └─ EndpointAccessNameRule (tabla puente)
                                       └─ endpointAccess → permission (string)
```

Al hacer login, `EndpointAccessRepositorio.GetEndpoints()` recorre esta cadena con un JOIN y devuelve la lista de
`PermisosXAsignacion` que luego se empaqueta en el JWT.

---

## Modelos de datos

### Users

| Campo       | Tipo           | Descripción                     |
|-------------|----------------|---------------------------------|
| `id`        | int            | PK                              |
| `userName`  | string (255)   | Nombre de usuario único         |
| `password`  | string (500)   | Hash Argon2                     |
| `name`      | string (50)    | Nombre                          |
| `app`       | string (50)    | Apellido paterno                |
| `apm`       | string (50)    | Apellido materno                |
| `imageUser` | string (500)   | URL de imagen de perfil         |
| `created`   | DateTimeOffset | Fecha de creación               |
| `status`    | bool           | Activo/inactivo (default: true) |

### Roles

| Campo        | Tipo            | Descripción                            |
|--------------|-----------------|----------------------------------------|
| `id`         | int             | PK                                     |
| `code`       | RoleCode (enum) | Tipo de rol predefinido por el sistema |
| `name`       | string (50)     | Nombre del rol                         |
| `created`    | DateTimeOffset  | Fecha de creación                      |
| `idNameRule` | int?            | FK → NameRule                          |

**RoleCode (enum):** `Director=1`, `Gerente=2`, `Supervisor=3`, `Coordinador=4`, `Empleado=5`

### NameRule

Agrupa un conjunto de accesos a endpoints bajo un nombre. Se asigna a uno o más roles.

| Campo  | Tipo        | Descripción                              |
|--------|-------------|------------------------------------------|
| `id`   | int         | PK                                       |
| `name` | string (50) | Nombre de la regla (ej. "Acceso de CEO") |

### endpointAccess

Catálogo de permisos disponibles en el sistema.

| Campo        | Tipo   | Descripción                                     |
|--------------|--------|-------------------------------------------------|
| `id`         | int    | PK                                              |
| `endpoint`   | string | Ruta del endpoint (ej. `/auth/logout`)          |
| `method`     | string | Método HTTP                                     |
| `permission` | string | Identificador del permiso (ej. `auth.logout.*`) |
| `status`     | bool   | Activo/inactivo                                 |

### EndpointAccessNameRule

Tabla puente entre `endpointAccess` y `NameRule`.

| Campo              | Tipo | Descripción         |
|--------------------|------|---------------------|
| `id`               | int  | PK                  |
| `idEndpointAccess` | int  | FK → endpointAccess |
| `idNameRule`       | int  | FK → NameRule       |

### UserAssignments

Asignación de un usuario a un rol dentro de un scope.

| Campo          | Tipo             | Descripción                                    |
|----------------|------------------|------------------------------------------------|
| `id`           | int              | PK                                             |
| `idUser`       | int              | FK → Users                                     |
| `codeEmployee` | string (15)?     | Código de empleado                             |
| `idRole`       | int              | FK → Roles                                     |
| `scopeType`    | scopeType (enum) | Tipo de contexto                               |
| `scopeId`      | int?             | ID de la entidad del scope (área, fecha, etc.) |
| `created`      | DateTimeOffset   | Fecha de creación                              |
| `isActive`     | bool             | Activo/inactivo                                |

> El índice único es `(scopeId, scopeType, idUser, idRole)` — un usuario no puede tener el mismo rol en el mismo scope
> dos veces.

### refreshTokens

| Campo              | Tipo           | Descripción                                           |
|--------------------|----------------|-------------------------------------------------------|
| `id`               | int            | PK                                                    |
| `tokenHash`        | string         | Hash HMAC-SHA256 del refresh token                    |
| `expiresAt`        | DateTimeOffset | Expiración técnica del token                          |
| `SessionExpiresAt` | DateTimeOffset | Expiración por política (medianoche del día en curso) |
| `createdAt`        | DateTimeOffset | Fecha de creación                                     |
| `agentUserName`    | string         | User-Agent del cliente                                |
| `ipAddress`        | string         | IP del cliente                                        |
| `idUser`           | int            | FK → Users                                            |
| `isActive`         | bool           | Activo/inactivo                                       |

---

## Endpoints

### AuthController — `POST /Auth`

| Endpoint        | Método | Auth        | Permiso            | Descripción                                                 |
|-----------------|--------|-------------|--------------------|-------------------------------------------------------------|
| `/Auth`         | POST   | No          | —                  | Login. Devuelve Access Token y setea cookie `refreshToken`. |
| `/Auth/refresh` | POST   | No (cookie) | —                  | Renueva el Access Token usando la cookie `refreshToken`.    |
| `/Auth/Logout`  | POST   | Bearer      | `auth.logout.self` | Cierra la sesión actual invalidando el refresh token.       |

---

## Configuración

Variables relevantes en `appsettings.json` / variables de entorno:

| Clave                                 | Descripción                                                                         |
|---------------------------------------|-------------------------------------------------------------------------------------|
| `Jwt:Issuer`                          | Emisor del JWT                                                                      |
| `Jwt:Audience`                        | Audiencia del JWT                                                                   |
| `Jwt:AccessTokenMinutes`              | Duración del Access Token en minutos                                                |
| `Jwt:RefreshTokenDays`                | Duración técnica del Refresh Token en días                                          |
| `Jwt:PrivateKeyPath`                  | Ruta al archivo PEM de clave privada RSA                                            |
| `Jwt:PublicKeyPath`                   | Ruta al archivo PEM de clave pública RSA                                            |
| `JWT_PRIVATE_KEY_PEM`                 | (env var) Clave privada RSA en texto plano — tiene prioridad sobre `PrivateKeyPath` |
| `JWT_PUBLIC_KEY_PEM`                  | (env var) Clave pública RSA en texto plano — tiene prioridad sobre `PublicKeyPath`  |
| `Jwt:secretWord`                      | Clave secreta para HMAC-SHA256 del refresh token                                    |
| `ConnectionStrings:conexionSqlServer` | Cadena de conexión a SQL Server                                                     |

### Logs

Serilog escribe en dos destinos:

- **Consola**: todos los niveles.
- **Archivo**: `Logs/reportsError/reportErrorLog{Date}.log`, solo nivel `Error`, rotación diaria.

---

## Notas de desarrollo

- CORS configurado para `localhost:4200` y `localhost:4201` (Angular). Ajustar en producción.
- `Secure = false` en la cookie del refresh token — cambiar a `true` en producción con HTTPS.
- `app.UseHttpsRedirection()` está comentado — habilitar en producción.
- `ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning))` — remover en producción.
- El proxy reverso (Nginx) debe configurar el header `X-Forwarded-For` para que `HttpContextService` resuelva
  correctamente la IP del cliente.

---

## Recursos de desarrollo

| Documento                                                         | Descripción                                                                          |
|-------------------------------------------------------------------|--------------------------------------------------------------------------------------|
| [Accesos por Rol](recursosDev/Documentacion/AccessForRoles.md)    | Tabla teórica y sintáctica de permisos por rol y módulo, con ejemplos de claims JWT. |
| [Posibles Bugs – Login](recursosDev/Posibles%20Bugs/LoginBugs.md) | Análisis de posible inconsistencia de atomicidad en el flujo de Refresh Token.       |
