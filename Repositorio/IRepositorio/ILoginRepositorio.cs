namespace SystemBase.Repositorio.IRepositorio;
using Models;
public interface ILoginRepositorio
{
    users? LoginUser(string userName, string password);
}