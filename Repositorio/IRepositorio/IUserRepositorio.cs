using SystemBase.Models;
using SystemBase.Models.Snapshot;

namespace SystemBase.Repositorio.IRepositorio;

public interface IUserRepositorio
{
    Task<string?> GetPasswordByIdAsync(int id);
    Task<List<userDashboardDTO>> GetAllUsers(HierarchyFilter? filter);
}