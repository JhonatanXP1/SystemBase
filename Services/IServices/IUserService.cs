using SystemBase.Models.Snapshot;

namespace SystemBase.Services.IServices;

public interface IUserService
{
    Task<ResponseService<string>> GetPasswordHash(int id);
    Task<ResponseService<List<userDashboardDTO>>> GetAllUsers(string scope);
    //Task<ResponseService<string>> GetUserById(int id);
}