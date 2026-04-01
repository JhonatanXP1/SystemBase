using Microsoft.EntityFrameworkCore;
using SystemBase.Models.Snapshot;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services.IServices;

namespace SystemBase.Services;

public class UserAssignmentsService(
    IEndpointAccessRepositorio accessRepositorio,
    ILogger<UserAssignmentsService> logger) : IUserAssignments
{
    private readonly IEndpointAccessRepositorio _endpointAccessRepositorio = accessRepositorio;
    private readonly ILogger<UserAssignmentsService> _logger = logger;

    public async Task<ResponseService<List<PermisosXAsignacion>>> GetAllPermissionFromAssignate(int idUser)
    {
        try
        {
            var asignaciones = await _endpointAccessRepositorio.GetEndpoints(idUser);
            return ResponseService.Success(asignaciones);
        }
        catch (DbUpdateException expcionDbContext)
        {
            _logger.LogError($"Algo ha fallado: {expcionDbContext.Message}");
            return ResponseService.Error<List<PermisosXAsignacion>>("");
        }
    }
}