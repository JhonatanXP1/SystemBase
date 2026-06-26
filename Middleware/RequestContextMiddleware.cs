using System.IdentityModel.Tokens.Jwt;
using SystemBase.Services.IServices;

namespace SystemBase.Middleware;

// Rellena el IRequestContext al inicio de cada petición leyendo claims del JWT (ya autenticado)
// + header X-Active-Scope + datos de conexión (IP/UserAgent). Debe registrarse DESPUÉS de
// UseAuthentication y ANTES de UseAuthorization (para que el PermissionAuthorizationHandler
// pueda escribir MatchedPermissions sobre el contexto ya inicializado).
public class RequestContextMiddleware
{
    private readonly RequestDelegate _next;

    public RequestContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, IRequestContextInitializer initializer)
    {
        var subClaim = httpContext.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        var userId = int.TryParse(subClaim, out var id) ? id : (int?)null;
        var userName = httpContext.User.FindFirst(JwtRegisteredClaimNames.UniqueName)?.Value;

        var activeScope = httpContext.Request.Headers.TryGetValue("X-Active-Scope", out var scope)
            ? scope.ToString()
            : null;
        if (string.IsNullOrWhiteSpace(activeScope)) activeScope = null;

        var ip = httpContext.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedFor)
            ? forwardedFor.FirstOrDefault()?.Split(',').FirstOrDefault()?.Trim()
            : httpContext.Connection.RemoteIpAddress?.ToString();

        var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
        var requestId = Guid.NewGuid().ToString("N")[..12]; // 12 chars suficiente para correlación

        initializer.Initialize(userId, userName, activeScope, ip ?? "", userAgent, requestId);

        await _next(httpContext);
    }
}
