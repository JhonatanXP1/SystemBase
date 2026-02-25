## Tabla de Bugs
- [Nota sobre Refresh Token](#refresh-token-issue)

<h2 id="refresh-token-issue"> 📌 Nota Técnica – Posible Inconsistencia en Refresh Token (Falta de Atomicidad)</h2>

## 📖 Descripción

En el flujo de autenticación, cuando un usuario alcanza el número máximo permitido de refresh tokens activos (por ejemplo: 3), el sistema realiza las siguientes operaciones:

1. Desactiva el refresh token más antiguo.
2. Inserta un nuevo refresh token.

Estas operaciones se ejecutan en comandos separados y sin una transacción explícita que garantice atomicidad.

---

## ⚠️ Riesgo Potencial

Si ocurre una falla después de desactivar el token antiguo pero antes de insertar el nuevo (por ejemplo: `DbUpdateException`, timeout, deadlock, problema de red o reinicio del servicio), el sistema puede quedar en un estado parcialmente actualizado.

### Posible estado inconsistente:

- El refresh token antiguo queda desactivado.
- El nuevo refresh token no se crea.
- El usuario pierde una sesión activa.
- El sistema retorna HTTP 500.

---

## 🎯 Impacto

- ❌ No compromete la seguridad.
- ❌ No genera corrupción de datos.
- ❌ No afecta la integridad estructural de la base de datos.
- ⚠️ Puede afectar la experiencia de usuario.

### Posibles efectos visibles:

- El usuario debe iniciar sesión nuevamente.
- Pérdida inesperada de una sesión activa.
- Mensajes de error intermitentes.
- Tickets tipo: "me pidió login otra vez".

---

## 🔍 Escenarios que pueden detonar el problema

- Deadlocks bajo alta concurrencia.
- Timeout en SQL Server.
- Interrupción de red entre aplicación y base de datos.
- Excepción por constraint o índice.
- Reinicio del servidor durante la operación.

---

## 📊 Probabilidad

- Baja en entornos de bajo tráfico.
- Moderada en sistemas con alta concurrencia.
- Aumenta proporcionalmente al volumen de logins o refresh mensuales.

La probabilidad acumulada crece con el número total de operaciones ejecutadas.

---

## 🟡 Severidad

**Baja a Media**

Impacta principalmente la experiencia del usuario, no la seguridad ni la integridad del sistema.

---

## 🛠 Posible Mejora Futura

Implementar una transacción explícita que envuelva:

- La desactivación del refresh token antiguo.
- La inserción del nuevo refresh token.

Objetivo: Garantizar atomicidad (todo o nada) y evitar estados intermedios inconsistentes.

---

## 📌 Estado Actual

Se considera un comportamiento tolerable en el contexto actual del sistema.

Se documenta como posible mejora futura en caso de:

- Aumento de tráfico.
- Mayor criticidad del sistema.
- Requerimientos de alta disponibilidad o consistencia estricta.