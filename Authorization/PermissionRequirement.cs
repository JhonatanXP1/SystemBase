using Microsoft.AspNetCore.Authorization;
namespace SystemBase.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{                                                                                                                                                                                                                                          
    public List<string> permissions { get; }
                                                                                                                                                                                                                                             
    public PermissionRequirement(string[] permissions)
    {
        this.permissions = permissions.ToList();
    }                                                                                                                                                                                                                                      
}
