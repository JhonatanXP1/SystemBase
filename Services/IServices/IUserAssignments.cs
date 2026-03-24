namespace SystemBase.Services.IServices;

public interface IUserAssignments
{
    Task<bool> GetAllPermissionFromAssignate(int idUser);
}