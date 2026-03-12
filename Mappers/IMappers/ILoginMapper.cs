using SystemBase.Models.Snapshot;

namespace SystemBase.Mappers.IMappers;
using Models.DTO;
using Models;

public interface ILoginMapper
{
    UserSessionDTO MapUserToUserSessionDto(users user);
    public sessionStartedDto MapTosessionStartedsessionStartedDto(SessionStarted started);
    public refreshTokenResponseDTO MapTorefreshTokenResponseDTO(refreshToken token);
}