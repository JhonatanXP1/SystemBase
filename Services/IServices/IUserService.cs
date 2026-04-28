namespace SystemBase.Services.IServices;

public interface IUserService
{
    Task<ResponseService<string>> GetPasswordHash(int id);
}