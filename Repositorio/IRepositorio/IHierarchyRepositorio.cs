using SystemBase.Models;

namespace SystemBase.Repositorio.IRepositorio;

public interface IHierarchyRepositorio
{
    Task<IQueryable<Roles>> GetFilterHierarchy(int? idUser, string scopeName, int? scopeId);
}