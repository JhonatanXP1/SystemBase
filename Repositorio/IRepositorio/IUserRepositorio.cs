using SystemBase.Models;
using SystemBase.Models.ReadModels;

namespace SystemBase.Repositorio.IRepositorio;

public interface IUserRepositorio
{
    Task<string?> GetPasswordByIdAsync(int id);
    Task<List<UserDashboardRow>> GetAllUsers(HierarchyFilter? filter);
    
    Task<int>  GetUsersCountAsync(HierarchyFilter? filter);
}