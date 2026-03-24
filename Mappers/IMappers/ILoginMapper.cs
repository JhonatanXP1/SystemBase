using SystemBase.Models;
using SystemBase.Models.DTO;
using SystemBase.Models.Snapshot;

namespace SystemBase.Mappers.IMappers;

public interface ILoginMapper
{
    UserSessionDTO MapUserToUserSessionDto(Users user);
    public sessionStartedDto MapTosessionStartedsessionStartedDto(SessionStarted started);
    public refreshTokenResponseDTO MapTorefreshTokenResponseDTO(refreshToken token);
}