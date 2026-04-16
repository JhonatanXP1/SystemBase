using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SystemBase.Mappers.IMappers;
using SystemBase.Models;
using SystemBase.Models.DTO;
using SystemBase.Models.Snapshot;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services.IServices;

namespace SystemBase.Services;

public class LoginService : ILoginService
{
    private readonly IConfiguration _configuration;
    private readonly ILoginMapper _loginMapper;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ILoginRepositorio _repositorioLogin;
    private readonly ITokenService _tokenService;
    private readonly IUserAssignments _userAssignments;
    private readonly ILogger<LoginService> _logger;

    public LoginService(
        ILoginRepositorio repositorioLogin,
        ILoginMapper loginMapper,
        ITokenService tokenService,
        IConfiguration configuration,
        IPasswordHasher passwordHasher,
        IUserAssignments userAssignments,
        ILogger<LoginService> logger
    )
    {
        _repositorioLogin = repositorioLogin;
        _loginMapper = loginMapper;
        _tokenService = tokenService;
        _configuration = configuration;
        _passwordHasher = passwordHasher;
        _userAssignments = userAssignments;
        _logger = logger;
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

        // Se validan los accesos a los endpoints correspondientes al usuario autenticado, y posteriormente se agregan como claims en el JWT.
        var listPermission = await _userAssignments.GetAllPermissionFromAssignate(user.id);
        if (!listPermission.success ||  listPermission.data == null)
        {
            _logger.LogError("Error al obtener permisos");
            return ResponseService.Error<SessionStarted>("Error al obtener permisos");
        }
        
        var userSessionDto = _loginMapper.MapUserToUserSessionDto(user);

        var (token, expiresAt) = _tokenService.CreateAccessToken(userSessionDto, listPermission.data);
        var refreshToken = _tokenService.CreateRefreshToken();

        var numSessionActives = await _repositorioLogin.CountRefreshTokensExistAsyncron(user.id);

        //Los dias que la session se mantendrá viva.
        var days = _configuration.GetValue<int>("Jwt:RefreshTokenDays");
        var fechaExpi = DateTimeOffset.UtcNow.AddDays(days);
        DateTimeOffset fechaExpiPolitica = DateTimeOffset.UtcNow.Date.AddDays(1).AddSeconds(-1);

        var tokenHash = _tokenService.HashRefreshToken(refreshToken);

        if (numSessionActives >= 3) // Si tiene 3 o mas se va cancelar uno. para mantener solo 3 credenciales activas.
        {
            var oldRefreshTokens = await _repositorioLogin.GetOldRefreshTokens(user.id);
            var refreshTokenOld = oldRefreshTokens.OrderBy(r => r.createdAt).FirstOrDefault()!;
            try
            {
                await _repositorioLogin.DisabledRefreshToken(refreshTokenOld.id);
            }
            catch (DbUpdateException ex)
            {
                var root = ex.GetBaseException(); // <- aquí vive el error real de SQL Server
                _logger.LogError(ex.Message);
                _logger.LogError(root.Message);
                if (ex.InnerException != null)
                    _logger.LogError(ex.InnerException.Message);

                return ResponseService.Error<SessionStarted>("Error DB");
            }
        }

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
            return ResponseService.Success(new SessionStarted
            {
                Token = token,
                ExpiresAt = expiresAt,
                RefreshToken = refreshToken,
                refreshExpiresAt = fechaExpi,
                User = _loginMapper.MapUserToUserSessionDto(user)
            });
        }
        catch (DbUpdateException exceptionUpdateException)
        {
            _logger.LogError($"No se inserto RefreshTokens:\n {exceptionUpdateException.Message}");
            return ResponseService.Error<SessionStarted>($"No se inserto RefreshTokens");
        }
    }

    public async Task<ResponseService<refreshToken>> RefreshTokensService(string refreshToken,
        string ipAddress, string agentUserName)
    {
        var tokenHash = _tokenService.HashRefreshToken(refreshToken);
        var refreshTokenDb = await _repositorioLogin.RefreshTokensExist(tokenHash);
        if (refreshTokenDb == null) return ResponseService.Error<refreshToken>("Refresh token inválido");
        if (refreshTokenDb.ipAddress != ipAddress || refreshTokenDb.agentUserName != agentUserName)
        {
            await _repositorioLogin.DisabledRefreshTokensAll(0, tokenHash);
            return ResponseService.Error<refreshToken>("Refresh token inactivo");
        }

        if (!refreshTokenDb.isActive)
            return ResponseService.Error<refreshToken>("Refresh token inactivo");
        if (DateTimeOffset.UtcNow > refreshTokenDb.expiresAt)
        {
            await _repositorioLogin.DisabledRefreshToken(refreshTokenDb.id);
            return ResponseService.Error<refreshToken>("Refresh token expirado");
        }

        if (DateTimeOffset.UtcNow > refreshTokenDb.SessionExpiresAt)
        {
            await _repositorioLogin.DisabledRefreshToken(refreshTokenDb.id);
            return ResponseService.Error<refreshToken>("Sesión expirada, inicie sesión nuevamente");
        }

        var user = await _repositorioLogin.UserClaimNeed(refreshTokenDb.idUser);
        if (user == null) return ResponseService.Error<refreshToken>("Usuario no existe");
        
        // Se validan los accesos a los endpoints correspondientes al usuario autenticado, y posteriormente se agregan como claims en el JWT.
        var listPermission = await _userAssignments.GetAllPermissionFromAssignate(user.id);
        if (!listPermission.success ||  listPermission.data == null)
        {
            _logger.LogError("Error al obtener permisos");
            return ResponseService.Error<refreshToken>("Error al obtener permisos");
        }

        var (token, expiresAt) = _tokenService.CreateAccessToken(user, listPermission.data);
        var refreshTokenNew = _tokenService.CreateRefreshToken();
        var days = _configuration.GetValue<int>("Jwt:RefreshTokenDays");
        var fechaExpi = DateTimeOffset.UtcNow.AddDays(days);
        DateTimeOffset fechaExpiPolitica = DateTimeOffset.UtcNow.Date.AddDays(1).AddSeconds(-1);

        var tokenHashNew = _tokenService.HashRefreshToken(refreshTokenNew);
        if (await _repositorioLogin
                .TryDisabledRefreshTokens(refreshTokenDb
                    .id)) // <-- Desactivas el Refresh Activo Actual y Renuevas uno nuevo.
            try
            {
                await _repositorioLogin.AddRefreshTokens(new refreshTokens
                {
                    createdAt = DateTimeOffset.UtcNow,
                    tokenHash = tokenHashNew,
                    expiresAt = fechaExpi,
                    SessionExpiresAt = fechaExpiPolitica,
                    agentUserName = agentUserName,
                    ipAddress = ipAddress,
                    idUser = user.id,
                    isActive = true
                });
            }
            catch (DbUpdateException updateException)
            {
                _logger.LogError($"No se inserto RefreshTokens:\n {updateException.Message}");
                return ResponseService.Error<refreshToken>($"No se inserto RefreshTokens:\n {updateException.Message}");
            }

        return ResponseService.Success(new refreshToken
        {
            Token = token,
            ExpiresAt = expiresAt,
            RefreshToken = refreshTokenNew,
            refreshExpiresAt = fechaExpi
        });
    }

    public async Task<ResponseService<bool>> Logout(string refreshToken)
    {
        var tokenHash = _tokenService.HashRefreshToken(refreshToken);
        var refreshTokenDb = await _repositorioLogin.RefreshTokensExist(tokenHash);

        if (refreshTokenDb == null)
            return ResponseService.Error<bool>("Refresh token inválido");

        await _repositorioLogin.DisabledRefreshToken(refreshTokenDb.id);

        return ResponseService.Success(true);
    }
}