using SystemBase.Services.IServices;

namespace SystemBase.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SystemBase.Models.DTO;

[Route("[controller]")]
[ApiController]
public class AuthController: ControllerBase
{
    readonly ILoginService _loginService;
    public AuthController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(sessionStartedDTO))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Login([FromBody]logingDTO loging)
    {
        //Identificas la IP publica.
        string? ipAddress = Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedFor) // Recuerda!!! configurar Nginx
            ? forwardedFor.FirstOrDefault()?.Split(',').FirstOrDefault()?.Trim()
            : HttpContext.Connection.RemoteIpAddress?.ToString();
        
        string userAgent = Request.Headers["User-Agent"].ToString();
        
        
        return Ok();
    }
}