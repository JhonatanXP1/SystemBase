using System.Security.Claims;
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
    readonly  IHttpContextService _accessor; // Inyectamos el IHttpContextAccessor para obtener la IP y el User-Agent
    public AuthController(ILoginService loginService, IHttpContextService accessor)
    {
        _loginService = loginService;
        _accessor = accessor;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(sessionStartedDTO))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody]logingDTO loging)
    {
        //Identificas la IP publica.
        string? ipAddress = _accessor.GetClientIpAddress();
        string userAgent = _accessor.GetUserAgent();
        
        var generarToken = await _loginService.Login(loging, userAgent, ipAddress);

        if (!generarToken.Success)
        {
            switch (generarToken.Error)
            {
                case "Credenciales inválidas":
                    return Unauthorized(generarToken.Error);
                    break;
                default: BadRequest(generarToken.Error);
                    break;
            }
        }
        return Ok(generarToken.Data);
    }

    [HttpPost("refresh")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(sessionStartedDTO))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RefreshToken([FromBody] refreshTokenDTO refreshToken)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        foreach (var claim in User.Claims)
        {
            Console.WriteLine($"{claim.Type} : {claim.Value}");
        }
        var userId = int.Parse(userIdClaim?.Value ?? "0");
        if (userId == 0) return Unauthorized("Token inválido");
        
        return Ok();
    }
}