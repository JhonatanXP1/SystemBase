namespace SystemBase.Repositorio.IRepositorio;
using Models;
public interface ILoginRepositorio
{
    users? LoginUser(string userName, string password);
    List<refreshTokens> ListRefreshTokensExist(int userId);
    int CountRefreshTokensExist(int userId);
    
}