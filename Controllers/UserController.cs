using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        string? id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (id == null)
            return Unauthorized();
        
        
        return Ok();
    }
}