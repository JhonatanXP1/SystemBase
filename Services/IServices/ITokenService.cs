namespace SystemBase.Services.IServices;
using SystemBase.Models.DTO;
public interface ITokenService
{
    public (string token, DateTime expiresAt) CreateAccessToken(UserSessionDTO user);
    public string CreateRefreshToken();
}