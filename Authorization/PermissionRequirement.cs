using Microsoft.AspNetCore.Authorization;

namespace SystemBase.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(string[] permissions)
    {
        this.permissions = permissions.ToList();
    }

    public List<string> permissions { get; }
}