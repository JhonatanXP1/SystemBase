using SystemBase.Models.Snapshot;

namespace SystemBase.Services.IServices;
using Services;
using Models.DTO;

public interface ILoginService
{
    Task<ResponseService<SessionStarted>> Login(logingDTO loginDto, string agentUserName, string ipAddress);
    Task<ResponseService<refreshToken>> refreshTokensService(string refreshToken, string ipAddress,
        string agentUserName);
    Task<ResponseService<bool>> Logout(string idUser);
}