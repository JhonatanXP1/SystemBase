using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using SystemBase.Services;

namespace SystemBase.Authorization;

public class PermissionAuthorizationHandler(IHttpContextAccessor httpContextAccessor, ILogger<PermissionAuthorizationHandler> logger)
    : AuthorizationHandler<PermissionRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly ILogger<PermissionAuthorizationHandler> _logger = logger;

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null) { context.Fail(); return Task.CompletedTask; }

        // 1. Lee X-Active-Scope del header
        if (!httpContext.Request.Headers.TryGetValue("X-Active-Scope", out var activeScope)
            || string.IsNullOrWhiteSpace(activeScope))
        {
            context.Fail();
            return Task.CompletedTask;
        }

        // 2. Extrae el claim perm del JWT
        var permClaim = context.User.FindFirst("perm")?.Value;
        if (string.IsNullOrWhiteSpace(permClaim)) { context.Fail(); return Task.CompletedTask; }

        // 3. Deserializa → "COMPANY:1", ["auth.logout.self", ...]
        var perms = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(permClaim);
        if (perms == null || !perms.TryGetValue(activeScope!, out var scopePermissions))
        {
            context.Fail();
            return Task.CompletedTask;
        }

        // 4. Valida OR: si satisface cualquiera de los permisos requeridos (con wildcard)
        if (requirement.permissions.Any(necesita =>
                scopePermissions.Any(tienes => SatisfacePermiso(tienes, necesita))))
            context.Succeed(requirement);
        else
            context.Fail();

        return Task.CompletedTask;
    }
    
    private static bool SatisfacePermiso(string tienes, string necesitas)
    {
        var partesT = tienes.Split('.');
        var partesN = necesitas.Split('.');

        if (partesT.Length != partesN.Length) return false;

        for (int i = 0; i < partesT.Length; i++)
        {
            if (partesT[i] == "*") continue;
            if (partesT[i] != partesN[i]) return false;
        }

        return true;
    }

}