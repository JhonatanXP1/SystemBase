using SystemBase.Models.Snapshot;

namespace SystemBase.Services.IServices;

public interface ITokenService
{
    (string token, DateTimeOffset expiresAt) CreateAccessToken(IUserTokenInfo user, ITokenPermisionFromUser permision);
    string CreateRefreshToken();
    string HashRefreshToken(string refreshToken);
}