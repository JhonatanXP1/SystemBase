using SystemBase.Models.Snapshot;

namespace SystemBase.Services.IServices;

public interface ITokenService
{
    (string token, DateTimeOffset expiresAt) CreateAccessToken(IUserTokenInfo user, List<PermisosXAsignacion> permisions);
    string CreateRefreshToken();
    string HashRefreshToken(string refreshToken);
}