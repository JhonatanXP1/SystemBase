using SystemBase.Models;
using SystemBase.Models.ReadModels;
using SystemBase.Services;

namespace SystemBase.Repositorio.IRepositorio;

public interface IUserRepositorio
{
    Task<string?> GetPasswordByIdAsync(int id);
    Task<List<UserDashboardRow>> GetAllUsers(HierarchyFilter? filter , endpointUsers typeQuery);

    Task<int> GetUsersCountAsync(HierarchyFilter? filter,  endpointUsers typeQuery);
}