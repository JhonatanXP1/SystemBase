using System.Security.Claims;
using SystemBase.Mappers.IMappers;
using SystemBase.Services.IServices;

namespace SystemBase.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.snapshot;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    readonly ILoginService _loginService;
    readonly IHttpContextService _accessor; // Inyectamos el IHttpContextAccessor para obtener la IP y el User-Agent
    readonly ILoginMapper _loginMapper;

    public AuthController(
        ILoginService loginService,
        IHttpContextService accessor,
        ILoginMapper loginMapper)
    {
        _loginService = loginService;
        _accessor = accessor;
        _loginMapper = loginMapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(sessionStarted))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] logingDTO loging)
    {
        //Identificas la IP publica.
        string? ipAddress = _accessor.GetClientIpAddress();
        string userAgent = _accessor.GetUserAgent();

        var sessionStarted = await _loginService.Login(loging, userAgent, ipAddress);

        if (!sessionStarted.Success)
        {
            switch (sessionStarted.Error)
            {
                case "Credenciales inválidas":
                    return Unauthorized(sessionStarted.Error);
                    break;
                default:
                    return BadRequest(sessionStarted.Error);
                    break;
            }
        }

        var generarToken = _loginMapper.MapTosessionStartedsessionStartedDto(sessionStarted.Data!);
        Response.Cookies.Append(
            "refreshToken",
            sessionStarted.Data!.RefreshToken, //<-- Ciclo de vida 1 dia. Yo lo quiero que se logueen  minimo por cada dia.
            new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // true en prod con https
                SameSite = SameSiteMode.Lax, // o Lax / None según tu front
                Expires = sessionStarted.Data.refreshExpiresAt, // o DateTimeOffset
                Path = "/Auth/refresh" // súper recomendado: solo se envía a refresh
            });
        return Ok(generarToken); //<-- Su ciclo de vida es de 15min
    }

    [HttpPost("refresh")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(sessionStartedDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RefreshToken()
    {
        if (!Request.Cookies.TryGetValue("refreshToken", out var refreshToken) ||
            string.IsNullOrWhiteSpace(refreshToken))
            return Unauthorized("Refresh token faltante");
        
        string? ipAddress = _accessor.GetClientIpAddress();
        string userAgent = _accessor.GetUserAgent();
        
        return Ok();
    }
}