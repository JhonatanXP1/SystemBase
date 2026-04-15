using Microsoft.AspNetCore.Authorization;

namespace SystemBase.Authorization;

public class RequirePermissionAttribute : AuthorizeAttribute
{
    public RequirePermissionAttribute(params string[] permissions) : base($"Permission:{string.Join(",", permissions)}")
    {
    }
}