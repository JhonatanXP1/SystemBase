using SystemBase.Models.DTO;
namespace SystemBase.Services.IServices;

public interface ILoginService
{
    ResponseService<sessionStartedDTO> Login(logingDTO loging);
}