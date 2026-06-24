# Arquitectura: Perfiles Dinámicos por Rol — Orbita360

> **Estado:** Pendiente de implementación  
> **Stack:** ASP.NET Core + Dapper + SQL Server  
> **Módulo:** Usuarios del Sistema / Gestión de Personal

---

## Contexto

El sistema de autenticación (SystemBase) ya cuenta con `users`, `roles`, `userAssignments` y `refreshTokens`. La
necesidad es extender los datos personales de un usuario según su tipo de rol — un empleado tiene campos distintos a un
cliente o un proveedor — y además permitir que el cliente final defina esos campos desde la aplicación sin intervención
del dev.

---

## Decisión de diseño

Se descartaron dos enfoques:

**EAV global** (`datosExtras` con clave/valor sobre toda la entidad) — descartado por rendimiento: reconstruir un perfil
requiere N JOINs, sin tipado real en BD y con índices ineficientes.

**EF Core con modelos dinámicos** — descartado porque EF Core construye y cachea el `IModel` una sola vez en
`OnModelCreating`. Agregar una tabla nueva en runtime requeriría forzar una reconstrucción completa via
`IModelCacheKeyFactory`, que es una operación pesada con lock global. Este comportamiento no cambió en EF Core 10 (
noviembre 2025) y no está previsto cambiar en EF Core 11 (noviembre 2026).

**Decisión final:** tablas de perfil creadas en runtime vía DDL directo con Dapper, controladas por la tabla
`profileAccess`.

---

## Esquema de BD

```sql
-- Controla qué rol tiene acceso a qué tabla de perfil
profileAccess (
    id           INT IDENTITY(1,1) PRIMARY KEY,
    idRole       INT NOT NULL REFERENCES roles(id),
    profileTable NVARCHAR(60) NOT NULL,         -- nombre exacto de la tabla en BD
    canRead      BIT NOT NULL DEFAULT 0,
    canWrite     BIT NOT NULL DEFAULT 0,
    CONSTRAINT UQ_profileAccess UNIQUE (idRole, profileTable)
)
```

Las tablas de perfil **no existen en tiempo de desarrollo** — las crea el cliente final desde la app. Cada tabla creada
sigue esta estructura mínima:

```sql
CREATE TABLE [{nombreTabla}] (
    id     INT IDENTITY(1,1) PRIMARY KEY,
    idUser INT NOT NULL REFERENCES users(id),
    -- columnas definidas por el cliente
)
```

---

## Relaciones

```
roles (1) ──────────── (N) profileAccess
                              │
                              │ profileTable = nombre de tabla física
                              │
                        clienteProfile  ←── users (1:0..1)
                        empleadoProfile ←── users (1:0..1)
                        [cualquier tabla futura]
```

`profileAccess` es una tabla de control, no una FK a otra entidad. El campo `profileTable` es un string que apunta al
nombre físico de la tabla en SQL Server. Un rol puede tener múltiples filas en `profileAccess` (ej: Directivo puede leer
`clienteProfile` y `empleadoProfile`).

---

## Flujo de creación de perfil desde la app

```
Cliente define nombre y campos desde UI
        ↓
Backend valida nombre y tipos (whitelist estricta)
        ↓
Dapper ejecuta CREATE TABLE (DDL)
        ↓
Dapper inserta fila en profileAccess
        ↓
La tabla ya está disponible para consultas
```

---

## Implementación backend

### Servicio de creación

```csharp
public class PerfilDinamicoService
{
    private readonly IDbConnection _conn;

    // Tipos permitidos — whitelist explícita, nunca dinámica
    private static readonly HashSet<string> TiposPermitidos = new()
    {
        "nvarchar(100)", "nvarchar(500)", "int",
        "bit", "datetimeoffset", "decimal(18,2)"
    };

    public async Task CrearPerfilTablaAsync(CrearPerfilDto dto)
    {
        // 1. Validar nombre de tabla — solo alfanumérico y guión bajo
        if (!Regex.IsMatch(dto.Nombre, @"^[a-zA-Z_][a-zA-Z0-9_]{2,59}$"))
            throw new ValidationException("Nombre de tabla inválido");

        // 2. Validar que no existe ya en profileAccess
        var existe = await _conn.QueryFirstOrDefaultAsync<int>(
            "SELECT COUNT(1) FROM profileAccess WHERE profileTable = @t",
            new { t = dto.Nombre });
        if (existe > 0)
            throw new ValidationException("Ya existe un perfil con ese nombre");

        // 3. Validar columnas
        foreach (var col in dto.Columnas)
        {
            if (!Regex.IsMatch(col.Nombre, @"^[a-zA-Z_][a-zA-Z0-9_]{1,59}$"))
                throw new ValidationException($"Nombre de columna inválido: {col.Nombre}");

            if (!TiposPermitidos.Contains(col.Tipo))
                throw new ValidationException($"Tipo no permitido: {col.Tipo}");
        }

        // 4. Construir y ejecutar DDL
        var cols = string.Join(",\n    ", dto.Columnas
            .Select(c => $"[{c.Nombre}] {c.Tipo} {(c.Requerido ? "NOT NULL" : "NULL")}"));

        await _conn.ExecuteAsync($"""
            CREATE TABLE [{dto.Nombre}] (
                id     INT IDENTITY(1,1) PRIMARY KEY,
                idUser INT NOT NULL REFERENCES users(id)
                {(cols.Length > 0 ? "," + cols : "")}
            )
        """);

        // 5. Registrar en profileAccess
        await _conn.ExecuteAsync("""
            INSERT INTO profileAccess (idRole, profileTable, canRead, canWrite)
            VALUES (@idRole, @tabla, 1, 1)
        """, new { dto.IdRole, tabla = dto.Nombre });
    }
}
```

### Servicio de consulta

```csharp
public async Task<IEnumerable<dynamic>> LeerPerfilAsync(string tabla, int idUser, int idRole)
{
    // 1. Verificar acceso en profileAccess — nunca confiar en el cliente
    var acceso = await _conn.QueryFirstOrDefaultAsync(
        "SELECT canRead FROM profileAccess WHERE profileTable = @t AND idRole = @r",
        new { t = tabla, r = idRole });

    if (acceso == null || acceso.canRead == false)
        throw new UnauthorizedAccessException();

    // 2. Query dinámica — tabla ya validada contra profileAccess
    return await _conn.QueryAsync(
        $"SELECT * FROM [{tabla}] WHERE idUser = @id",
        new { id = idUser });
}
```

---

## Consideraciones de seguridad

El riesgo principal es SQL injection en nombres de tabla, ya que SQL Server no permite parámetros en DDL. La protección
es en dos capas:

**Capa 1 — Regex en creación:** el nombre solo puede contener letras, números y guión bajo. Ningún carácter especial
pasa.

**Capa 2 — Validación en consulta:** antes de cualquier SELECT, se verifica que `profileTable` existe en
`profileAccess`. Si alguien intenta consultar una tabla que no está registrada, se rechaza antes de armar el SQL.

Nunca usar el nombre de tabla directamente desde el request HTTP — siempre leerlo de `profileAccess` después de validar
el rol.

---

## Consideraciones operacionales

Cada cliente que crea perfiles genera tablas físicas en la BD. Con muchas instituciones esto puede derivar en cientos o
miles de tablas. Antes de implementar en producción considerar:

- Prefijo por tenant para evitar colisiones: `inst42_clienteProfile`
- Script de monitoreo para auditar tablas huérfanas (sin fila en `profileAccess`)
- Estrategia de backup que contemple tablas dinámicas
- Límite máximo de tablas por institución si es multi-tenant

---

## DTOs de referencia

```csharp
public record CrearPerfilDto(
    string Nombre,
    int IdRole,
    List<ColumnaDef> Columnas
);

public record ColumnaDef(
    string Nombre,
    string Tipo,       // debe estar en TiposPermitidos
    bool Requerido
);
```

---

## Lo que NO usar

| Alternativa                                  | Por qué no                                                                        |
|----------------------------------------------|-----------------------------------------------------------------------------------|
| EF Core migrations en runtime                | `IModel` se cachea al arrancar, reconstruirlo es costoso y con lock global        |
| `IModelCacheKeyFactory` para esto            | Diseñado para variantes de modelo, no para tablas completamente nuevas en runtime |
| EAV global (clave/valor)                     | N JOINs por perfil, sin tipado en BD, índices ineficientes                        |
| `dynamic` sin validar contra `profileAccess` | Exposición a SQL injection y acceso no autorizado a tablas                        |
