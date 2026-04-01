using SystemBase.Models.Snapshot;

namespace SystemBase.Services.IServices;

public interface IUserAssignments
{
    Task<ResponseService<List<PermisosXAsignacion>>> GetAllPermissionFromAssignate(int idUser);
}