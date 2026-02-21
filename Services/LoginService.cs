using System.Data;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Services;
using IServices;
using Models.DTO;
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

    public async Task<ResponseService<sessionStarted>> Login(logingDTO loginDto, string agentUserName, string ipAddress)
    {
        if (string.IsNullOrEmpty(loginDto.userName) || string.IsNullOrEmpty(loginDto.password))
            return ResponseService.Error<sessionStarted>("Usuario y contraseña son requeridos");

        var user = await _repositorioLogin.LoginUser(loginDto.userName);
        Console.WriteLine(JsonSerializer.Serialize(user));
        if (user == null)
            return ResponseService.Error<sessionStarted>("Credenciales inválidas");

        if (!_passwordHasher.Verify(user.password,
                loginDto.password)) // Validas Contraseña que esta Hasheada en Argoin2
            return ResponseService.Error<sessionStarted>("Credenciales inválidas");

        UserSessionDTO userSessionDto = _loginMapper.MapUserToUserSessionDto(user);

        var (token, expiresAt) = _tokenService.CreateAccessToken(userSessionDto);
        var refreshToken = _tokenService.CreateRefreshToken();

        int numSessionActives = await _repositorioLogin.CountRefreshTokensExistAsyncron(user.id);

        //Los dias que la session se mantendrá viva.
        int days = _configuration.GetValue<int>("Jwt:RefreshTokenDays");
        DateTimeOffset fechaExpi = DateTimeOffset.Now.AddDays(days);
        DateTimeOffset fechaExpiPolitica = DateTimeOffset.Now.Date.AddDays(1).AddSeconds(-1);

        string tokenHash = _tokenService.HashRefreshToken(refreshToken);

        if (numSessionActives >= 3) // Si tiene 3 o mas se va cancelar uno. para mantener solo 3 credenciales activas.
        {
            return ResponseService.Error<sessionStarted>("No implementado");
        }
        else
        {
            try
            {
                await _repositorioLogin.AddRefreshTokens(new refreshTokens
                {
                    createdAt = DateTimeOffset.Now,
                    tokenHash = tokenHash,
                    expiresAt = fechaExpi,
                    SessionExpiresAt = fechaExpiPolitica,
                    agentUserName = agentUserName,
                    ipAddress = ipAddress,
                    idUser = user.id,
                    isActive = true
                });
                return ResponseService.Success<sessionStarted>(new sessionStarted
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
                return ResponseService.Error<sessionStarted>($"No se inserto RefreshTokens:\n {eUP.Message}");
            }
        }


    }
    public async Task<ResponseService<refreshTokenResponseDTO>> refreshTokensService(string refreshToken, string ipAddress, string userAgent)
    {
            
    }
}