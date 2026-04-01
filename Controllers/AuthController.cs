using Microsoft.AspNetCore.Mvc;
using SystemBase.Mappers.IMappers;
using SystemBase.Models.DTO;
using SystemBase.Models.Snapshot;
using SystemBase.Services.IServices;

namespace SystemBase.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IHttpContextService
        _accessor; // Inyectamos el IHttpContextAccessor para obtener la IP y el User-Agent

    private readonly ILoginMapper _loginMapper;
    private readonly ILoginService _loginService;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SessionStarted))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] logingDTO loging)
    {
        //Identificas la IP publica.
        var ipAddress = _accessor.GetClientIpAddress();
        var userAgent = _accessor.GetUserAgent();

        var sessionStarted = await _loginService.Login(loging, userAgent, ipAddress);

        if (!sessionStarted.success)
            return sessionStarted.error switch
            {
                "Credenciales inválidas" =>
                    Unauthorized(sessionStarted.error),
                _ => BadRequest(sessionStarted.error)
            };

        var accessToken = _loginMapper.MapTosessionStartedsessionStartedDto(sessionStarted.data!);
        Response.Cookies.Append(
            "refreshToken",
            sessionStarted.data!
                .RefreshToken, //<-- Ciclo de vida 1 dia. Yo lo quiero que se logueen  minimo por cada dia.
            new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // true en prod con https
                SameSite = SameSiteMode.Lax, // o Lax / None según tu front
                Expires = sessionStarted.data.refreshExpiresAt, // o DateTimeOffset
                Path = "/Auth/refresh" // súper recomendado: solo se envía a refresh
            });
        return Ok(accessToken); //<-- Su ciclo de vida es de 15min
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

        var ipAddress = _accessor.GetClientIpAddress();
        var userAgent = _accessor.GetUserAgent();

        var newCredenciales = await _loginService.RefreshTokensService(refreshToken, ipAddress, userAgent);
        if (!newCredenciales.success)
            return newCredenciales.error switch
            {
                "Refresh token expirado" or
                    "Sesión expirada, inicie sesión nuevamente" or
                    "Refresh token inválido" or
                    "Usuario no existe"
                    => Unauthorized(newCredenciales.error),
                _ => BadRequest(newCredenciales.error)
            };
        Response.Cookies.Append("refreshToken", newCredenciales.data!
                .RefreshToken,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // true en prod con https
                SameSite = SameSiteMode.Lax, // o Lax / None según tu front
                Expires = newCredenciales.data.refreshExpiresAt, // o DateTimeOffset
                Path = "/Auth/refresh" // súper recomendado: solo se envía a refresh
            }
        );
        var accessToken = _loginMapper.MapTorefreshTokenResponseDTO(newCredenciales.data);
        return Ok(accessToken);
    }

    [HttpPost("Logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Logout()
    {
        return Ok();
    }
}