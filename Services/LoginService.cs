using System.Data;

namespace SystemBase.Services;
using IServices;
using Models.DTO;
using Mappers.IMappers;
using Repositorio.IRepositorio;

public class LoginService :ILoginService
{
    private readonly ILoginRepositorio _repositorioLogin;
    private readonly ILoginMapper _loginMapper;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;
    public LoginService(
        ILoginRepositorio repositorioLogin,
        ILoginMapper loginMapper,
        ITokenService tokenService,
        IConfiguration configuration
        )
    {
        _repositorioLogin = repositorioLogin;
        _loginMapper = loginMapper;
        _tokenService = tokenService;
        _configuration = configuration;
    }
    
    public async Task<ResponseService<sessionStartedDTO>> Login(logingDTO loginDto,  string agentUserName, string ipAddress)
    {
        if (string.IsNullOrEmpty(loginDto.userName) || string.IsNullOrEmpty(loginDto.password)) 
            return ResponseService.Error<sessionStartedDTO>("Usuario y contraseña son requeridos");
        
        var user = await _repositorioLogin.LoginUser(loginDto.userName, loginDto.password);
        
        if (user == null) 
            return ResponseService.Error<sessionStartedDTO>("No se encontró el usuario");

        UserSessionDTO userSessionDto = _loginMapper.MapUserToUserSessionDto(user);
        
        var (token, expiresAt) = _tokenService.CreateAccessToken(userSessionDto);
        var refreshToken = _tokenService.CreateRefreshToken();

        int numSessionActives = await _repositorioLogin.CountRefreshTokensExistAsyncron(user.id);
        
        //Los dias que la session se mantendrá vida.
        int days = _configuration.GetValue<int>("Jwt:RefreshTokenDays");
        DateTime fechaExpi = DateTime.UtcNow.AddDays(days);
        
        string tokenHash = _tokenService.HashRefreshToken(refreshToken);

        if (numSessionActives >= 3) // Si tiene 3 o mas se va cancelar uno. para mantener solo 3 credenciales activas.
        { 
            
        }
        else
        {
            
        }
        
        return ResponseService.Success<sessionStartedDTO>(new sessionStartedDTO());
    }
}