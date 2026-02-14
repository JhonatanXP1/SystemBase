namespace SystemBase.Repositorio.IRepositorio;
using Models;
public interface ILoginRepositorio
{
    Task<users?> LoginUser(string userName);
    Task<List<refreshTokens>> ListRefreshTokensExist(int userId);
    Task<int> CountRefreshTokensExistAsyncron(int userId);
    
    
}