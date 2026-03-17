using SystemBase.Models.Snapshot;

namespace SystemBase.Repositorio.IRepositorio;
using Models;

public interface ILoginRepositorio
{
    Task<Users?> LoginUser(string userName);
    Task<List<refreshTokens>> ListRefreshTokensExist(int userId);
    Task<int> CountRefreshTokensExistAsyncron(int userId);
    Task<List<OldRefreshToken>> GetOldRefreshTokens(int userId);
    Task DisabledRefreshToken(int idRefreshToken);
    Task DisabledRefreshTokensAll(int idUser = 0, string refreshToken = "");
    Task AddRefreshTokens(refreshTokens hashRefreshTokens);
    Task<refreshTokens?> RefreshTokensExist(string refreshToken);
    Task<UserNewAccessToken?> UserClaimNeed(int userId);
    Task<bool> TryDisabledRefreshTokens(int idRefreshToken);
}