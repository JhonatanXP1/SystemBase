using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SystemBase.Models.Snapshot;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services.IServices;

namespace SystemBase.Services;

public class UserAssignmentsService(IEndpointAccessRepositorio accessRepositorio) : IUserAssignments
{
    private readonly IEndpointAccessRepositorio _endpointAccessRepositorio = accessRepositorio;

    public async Task<ResponseService<List<PermisosXAsignacion>>> GetAllPermissionFromAssignate(int idUser)
    {
        try
        {
            var asignaciones = await _endpointAccessRepositorio.GetEndpoints(idUser);
            return ResponseService.Success(asignaciones);
        }
        catch (DbUpdateException expcionDbContext)
        {
            Console.WriteLine(expcionDbContext);
            return ResponseService.Error<List<PermisosXAsignacion>>($"Algo ha fallado: {expcionDbContext.Message}");
        }
    }
}