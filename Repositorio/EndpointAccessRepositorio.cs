using Microsoft.EntityFrameworkCore;
using SystemBase.Data;
using SystemBase.Models.Snapshot;
using SystemBase.Repositorio.IRepositorio;

namespace SystemBase.Repositorio;

public class EndpointAccessRepositorio(AplicationDbContext db) : IEndpointAccessRepositorio
{
    private readonly AplicationDbContext _db = db;

    /*public async Task<List<PermisosXAsignacion>> GetEndpoints(int idUserAssigments)
    {
        return await (
            from ua in _db.userAssignments
            join ean in _db.endpointAccessNameRules on ua.idRole equals ean.idRole
            join r in _db.nameRules on ean.idNameRule equals r.id
            join e in _db.endpointAccess on ean.idEndpointAccess equals e.id
            where ua.id == idUserAssigments && ua.isActive && e.status
            select new PermisosXAsignacion
            {
                idUserAssignaments =  ua.id,
                permission = e.permission,
                nameRule = r.name
            }
        ).ToListAsync();
    }*/
}