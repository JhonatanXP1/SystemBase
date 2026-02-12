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
    public LoginService(ILoginRepositorio repositorioLogin, ILoginMapper loginMapper, ITokenService tokenService)
    {
        _repositorioLogin = repositorioLogin;
        _loginMapper = loginMapper;
        _tokenService = tokenService;
    }
    
    public ResponseService<sessionStartedDTO> Login(logingDTO loginDto,  string agentUserName, string ipAddress)
    {
        if (string.IsNullOrEmpty(loginDto.userName) || string.IsNullOrEmpty(loginDto.password)) 
            return ResponseService.Error<sessionStartedDTO>("Usuario y contraseña son requeridos");
        
        var user = _repositorioLogin.LoginUser(loginDto.userName, loginDto.password);
        
        if (user == null) 
            return ResponseService.Error<sessionStartedDTO>("No se encontró el usuario");

        UserSessionDTO userSessionDto = _loginMapper.MapUserToUserSessionDto(user);
        
        var (token, expiresAt) = _tokenService.CreateAccessToken(userSessionDto);
        var refreshToken = _tokenService.CreateRefreshToken();

        var numSessionActives = _repositorioLogin.CountRefreshTokensExistAsync(user.id);
        
        
        
        return ResponseService.Success<sessionStartedDTO>(new sessionStartedDTO());
    }
}