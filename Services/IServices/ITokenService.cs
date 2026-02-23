namespace SystemBase.Services.IServices;
using Models.snapshot;
public interface ITokenService
{
    public (string token, DateTimeOffset expiresAt) CreateAccessToken(IUserTokenInfo user);
    public string CreateRefreshToken();
    string HashRefreshToken(string refreshToken);
}