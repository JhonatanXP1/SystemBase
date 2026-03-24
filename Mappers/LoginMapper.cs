using SystemBase.Mappers.IMappers;
using SystemBase.Models;
using SystemBase.Models.DTO;
using SystemBase.Models.Snapshot;

namespace SystemBase.Mappers;

public class LoginMapper : ILoginMapper
{
    public UserSessionDTO MapUserToUserSessionDto(Users user)
    {
        return new UserSessionDTO
        {
            id = user.id,
            userName = user.userName,
            name = user.name,
            app = user.app,
            apm = user.apm,
            status = user.status
        };
    }

    public sessionStartedDto MapTosessionStartedsessionStartedDto(SessionStarted started)
    {
        return new sessionStartedDto
        {
            Token = started.Token,
            ExpiresAt = started.ExpiresAt,
            User = started.User
        };
    }

    public refreshTokenResponseDTO MapTorefreshTokenResponseDTO(refreshToken token)
    {
        return new refreshTokenResponseDTO
        {
            Token = token.Token,
            ExpiresAt = token.ExpiresAt
        };
    }
}