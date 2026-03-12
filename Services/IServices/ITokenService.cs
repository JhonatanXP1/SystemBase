using SystemBase.Models.Snapshot;

namespace SystemBase.Services.IServices;

public interface ITokenService
{
    public (string token, DateTimeOffset expiresAt) CreateAccessToken(IUserTokenInfo user);
    public string CreateRefreshToken();
    string HashRefreshToken(string refreshToken);
}