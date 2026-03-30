using System.Text.Json;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services.IServices;

namespace SystemBase.Services;

public class UserAssignmentsService(IEndpointAccessRepositorio accessRepositorio) : IUserAssignments
{
    private readonly IEndpointAccessRepositorio _endpointAccessRepositorio = accessRepositorio;

    public async Task<bool> GetAllPermissionFromAssignate(int idUser)
    {
        var asignaciones = await _endpointAccessRepositorio.GetEndpoints(idUser);
        Console.Write(JsonSerializer.Serialize(asignaciones, new JsonSerializerOptions
        {
            WriteIndented = true
        }));
        return true;
    }
}