namespace SystemBase.Services;
using  SystemBase.Services.IServices;
using SystemBase.Models.DTO;

public class LoginService :ILoginService
{
    public  ResponseService<sessionStartedDTO> Login(logingDTO loginDTO)
    {
        
        return new ResponseService<sessionStartedDTO>();
    }
}