namespace SystemBase.Repositorio.IRepositorio;

public interface IEndpointAccessRepositorio
{
    Task<List<string>> GetEndpoints(int idUserAssigments);
}