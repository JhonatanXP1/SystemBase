using System.Data;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Services;

using IServices;
using Models.DTO;
using Models.snapshot;
using Mappers.IMappers;
using Repositorio.IRepositorio;

public class LoginService : ILoginService
{
    private readonly ILoginRepositorio _repositorioLogin;
    private readonly ILoginMapper _loginMapper;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;
    private readonly IPasswordHasher _passwordHasher;

    public LoginService(
        ILoginRepositorio repositorioLogin,
        ILoginMapper loginMapper,
        ITokenService tokenService,
        IConfiguration configuration,
        IPasswordHasher passwordHasher
    )
    {
        _repositorioLogin = repositorioLogin;
        _loginMapper = loginMapper;
        _tokenService = tokenService;
        _configuration = configuration;
        _passwordHasher = passwordHasher;
    }

    public async Task<ResponseService<SessionStarted>> Login(logingDTO loginDto, string agentUserName, string ipAddress)
    {
        if (string.IsNullOrEmpty(loginDto.userName) || string.IsNullOrEmpty(loginDto.password))
            return ResponseService.Error<SessionStarted>("Usuario y contraseña son requeridos");

        var user = await _repositorioLogin.LoginUser(loginDto.userName);
        Console.WriteLine(JsonSerializer.Serialize(user));
        if (user == null)
            return ResponseService.Error<SessionStarted>("Credenciales inválidas");

        if (!_passwordHasher.Verify(user.password,
                loginDto.password)) // Validas Contraseña que esta Hasheada en Argoin2
            return ResponseService.Error<SessionStarted>("Credenciales inválidas");

        UserSessionDTO userSessionDto = _loginMapper.MapUserToUserSessionDto(user);

        var (token, expiresAt) = _tokenService.CreateAccessToken(userSessionDto);
        var refreshToken = _tokenService.CreateRefreshToken();

        int numSessionActives = await _repositorioLogin.CountRefreshTokensExistAsyncron(user.id);

        //Los dias que la session se mantendrá viva.
        int days = _configuration.GetValue<int>("Jwt:RefreshTokenDays");
        DateTimeOffset fechaExpi = DateTimeOffset.UtcNow.AddDays(days);
        DateTimeOffset fechaExpiPolitica = DateTimeOffset.UtcNow.Date.AddDays(1).AddSeconds(-1);

        string tokenHash = _tokenService.HashRefreshToken(refreshToken);

        if (numSessionActives >= 3) // Si tiene 3 o mas se va cancelar uno. para mantener solo 3 credenciales activas.
        {
            return ResponseService.Error<SessionStarted>("No implementado");
        }
        else
        {
            try
            {
                await _repositorioLogin.AddRefreshTokens(new refreshTokens
                {
                    createdAt = DateTimeOffset.UtcNow,
                    tokenHash = tokenHash,
                    expiresAt = fechaExpi,
                    SessionExpiresAt = fechaExpiPolitica,
                    agentUserName = agentUserName,
                    ipAddress = ipAddress,
                    idUser = user.id,
                    isActive = true
                });
                return ResponseService.Success<SessionStarted>(new SessionStarted
                {
                    Token = token,
                    ExpiresAt = expiresAt,
                    RefreshToken = refreshToken,
                    refreshExpiresAt = fechaExpi,
                    User = _loginMapper.MapUserToUserSessionDto(user)
                });
            }
            catch (DbUpdateException eUP)
            {
                Console.WriteLine($"No se inserto RefreshTokens:\n {eUP.Message}");
                return ResponseService.Error<SessionStarted>($"No se inserto RefreshTokens:\n {eUP.Message}");
            }
        }
    }

    public async Task<ResponseService<refreshToken>> refreshTokensService(string refreshToken,
        string ipAddress, string agentUserName)
    {
        string tokenHash = _tokenService.HashRefreshToken(refreshToken);
        var refreshTokenDb = await _repositorioLogin.RefreshTokensExist(tokenHash);
        if (refreshTokenDb == null) return ResponseService.Error<refreshToken>("Refresh token inválido");
        if (refreshTokenDb.isActive == false)
            return ResponseService.Error<refreshToken>("Refresh token inactivo");
        if (DateTimeOffset.UtcNow > refreshTokenDb.expiresAt)
            return ResponseService.Error<refreshToken>("Refresh token expirado");
        if (DateTimeOffset.UtcNow > refreshTokenDb.SessionExpiresAt)
            return ResponseService.Error<refreshToken>("Sesión expirada, inicie sesión nuevamente");

        var user = await _repositorioLogin.UserClaimNeed(refreshTokenDb.id);
        if (user == null) return ResponseService.Error<refreshToken>("Usuario no existe");

        var (token, expiresAt) = _tokenService.CreateAccessToken(user);
        var refreshTokenNew = _tokenService.CreateRefreshToken();
        int days = _configuration.GetValue<int>("Jwt:RefreshTokenDays");
        DateTimeOffset fechaExpi = DateTimeOffset.UtcNow.AddDays(days);
        DateTimeOffset fechaExpiPolitica = DateTimeOffset.UtcNow.Date.AddDays(1).AddSeconds(-1);

        string tokenHashNew = _tokenService.HashRefreshToken(refreshToken);
        if (await _repositorioLogin.TryDisabledRefreshTokens(refreshTokenDb.id)) // <-- Desactivas el Refresh Activo Actual y Renuevas uno nuevo.
        {
            try
            {
                await _repositorioLogin.AddRefreshTokens(new refreshTokens
                {
                    createdAt = DateTimeOffset.UtcNow,
                    tokenHash = tokenHash,
                    expiresAt = fechaExpi,
                    SessionExpiresAt = fechaExpiPolitica,
                    agentUserName = agentUserName,
                    ipAddress = ipAddress,
                    idUser = user.id,
                    isActive = true
                });
            }
            catch (DbUpdateException eUP)
            {
                Console.WriteLine($"No se inserto RefreshTokens:\n {eUP.Message}");
                return ResponseService.Error<refreshToken>($"No se inserto RefreshTokens:\n {eUP.Message}");
            }
        }
        return ResponseService.Success<refreshToken>(new refreshToken
        {
            Token = token,
            ExpiresAt = expiresAt,
            RefreshToken = refreshToken,
            refreshExpiresAt = fechaExpi
        });
    }
}