namespace SystemBase.Repositorio.IRepositorio;

public interface IUserRepositorio
{
    Task<string?> GetPasswordByIdAsync(int id);
}