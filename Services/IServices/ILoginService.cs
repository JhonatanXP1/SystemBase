namespace SystemBase.Services.IServices;
using SystemBase.Services;
using SystemBase.Models.DTO;

public interface ILoginService
{
    ResponseService<sessionStartedDTO> Login(logingDTO loginDto, string agentUserName, string ipAddress);
}