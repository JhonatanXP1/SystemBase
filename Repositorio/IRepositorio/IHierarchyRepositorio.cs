using SystemBase.Models;

namespace SystemBase.Repositorio.IRepositorio;

public interface IHierarchyRepositorio
{
    Task<RoleCode?> GetFilterHierarchy(int? idUser, string scopeName, int? scopeId);
}