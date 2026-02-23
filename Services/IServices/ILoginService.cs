namespace SystemBase.Services.IServices;
using Services;
using Models.DTO;
using Models.snapshot;

public interface ILoginService
{
    Task<ResponseService<sessionStarted>> Login(logingDTO loginDto, string agentUserName, string ipAddress);
    Task<ResponseService<refreshTokenResponseDTO>> refreshTokensService(string refreshToken, string ipAddress, string agentUserName);
}