namespace SystemBase.Mappers.IMappers;
using Models.DTO;
using Models;

public interface ILoginMapper
{
    UserSessionDTO MapUserToUserSessionDto(users user);
    public sessionStartedDto MapTosessionStartedsessionStartedDto(sessionStarted started);
}