namespace SystemBase.Services;
using IServices;
using Models.DTO;
using Mappers.IMappers;
using Repositorio.IRepositorio;

public class LoginService :ILoginService
{
    private readonly ILoginRepositorio _repositorioLogin;
    private readonly ILoginMapper _loginMapper;
    public LoginService(ILoginRepositorio repositorioLogin, ILoginMapper loginMapper)
    {
        _repositorioLogin = repositorioLogin;
        _loginMapper = loginMapper;
    }
    public ResponseService<sessionStartedDTO> Login(logingDTO loginDto)
    {
        if (string.IsNullOrEmpty(loginDto.userName) || string.IsNullOrEmpty(loginDto.password)) 
            return ResponseService.Error<sessionStartedDTO>("Usuario y contraseña son requeridos");
        
        var user = _repositorioLogin.LoginUser(loginDto.userName, loginDto.password);
        
        if (user == null) 
            return ResponseService.Error<sessionStartedDTO>("No se encontró el usuario");

        UserSessionDTO userSessionDto = _loginMapper.MapUserToUserSessionDto(user);
        
        
        return ResponseService.Success<sessionStartedDTO>(new sessionStartedDTO());
    }
}