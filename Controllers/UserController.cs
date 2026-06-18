using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SystemBase.Authorization;
using SystemBase.Services.IServices;

namespace SystemBase.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class UserController(
    IHttpContextService httpContext
) : ControllerBase
{
    private readonly IHttpContextService _accessor = httpContext;

    [HttpGet("password")]
    public async Task<IActionResult> Password()
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (id == null)
            return Unauthorized();
        return Ok();
    }
    
    [RequirePermission("users.read.*","user.read.subordinate")]
    public async Task<IActionResult> Users()
    {
        if (!Request.Headers.TryGetValue("X-Active-Scope", out var activeScope)
            || string.IsNullOrWhiteSpace(activeScope))
            return BadRequest("X-Active-Scope requerido");
        
  
        
        
        return Ok();
    }
}