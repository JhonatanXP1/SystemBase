namespace SystemBase.Services.IServices;

public interface IUserService
{
    string GetPasswordHash(string id);
}