using SystemBase.Mappers.IMappers;
using SystemBase.Models.DTO;
using SystemBase.Models.snapshot;
using SystemBase.Models;
namespace SystemBase.Mappers;

public class LoginMapper : ILoginMapper
{
    public UserSessionDTO MapUserToUserSessionDto(users user)
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

    public sessionStartedDto MapTosessionStartedsessionStartedDto(sessionStarted started)
    {
        return new sessionStartedDto
        {
            Token = started.Token,
            ExpiresAt = started.ExpiresAt,
            User  = started.User
        };
    }
}