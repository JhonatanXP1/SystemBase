using SystemBase.Models.DTO;
using SystemBase.Models.Snapshot;

namespace SystemBase.Services.IServices;

public interface IUserService
{
    Task<ResponseService<string>> GetPasswordHash(int id);

    Task<ResponseService<UsersDashboardDto>> GetAllUsers(string scope, bool? isActive, bool? isDeleted, int? page,
        int? pageSize);
    //Task<ResponseService<string>> GetUserById(int id);
}