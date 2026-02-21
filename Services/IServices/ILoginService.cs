namespace SystemBase.Services.IServices;
using SystemBase.Services;
using SystemBase.Models.DTO;

public interface ILoginService
{
    Task<ResponseService<sessionStarted>> Login(logingDTO loginDto, string agentUserName, string ipAddress);
    Task<ResponseService<refreshTokenResponseDTO>> refreshTokensService(string refreshToken, string ipAddress, string userAgent);
}