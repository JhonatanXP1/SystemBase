using SystemBase.Models.DTO;
using SystemBase.Models.Snapshot;

namespace SystemBase.Services.IServices;

public interface ILoginService
{
    Task<ResponseService<SessionStarted>> Login(logingDTO loginDto, string agentUserName, string ipAddress);

    Task<ResponseService<refreshToken>> RefreshTokensService(string refreshToken, string ipAddress,
        string agentUserName);

    Task<ResponseService<bool>> Logout(string refreshToken);
}