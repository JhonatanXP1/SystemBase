using Microsoft.EntityFrameworkCore;
using SystemBase.Data;
using SystemBase.Models;
using SystemBase.Models.Snapshot;
using SystemBase.Repositorio.IRepositorio;

namespace SystemBase.Repositorio;

public class EndpointAccessRepositorio(AplicationDbContext db) : IEndpointAccessRepositorio
{
    private readonly AplicationDbContext _db = db;

    public async Task<List<PermisosXAsignacion>> GetEndpoints(int idUser)
    {
        return await (
            from ua in _db.userAssignments
            join r in _db.roles on ua.idRole equals r.id
            join nr in _db.nameRules on r.idNameRule equals nr.id
            join eanr in _db.endpointAccessNameRules on nr.id equals eanr.idNameRule
            join ea in _db.endpointAccess on eanr.idEndpointAccess equals ea.id
            where ua.idUser == idUser && ua.isActive && ea.status
            select new PermisosXAsignacion
            {
                idUserAssignaments = ua.id,
                permission = ea.permission,
                nameRule = nr.name
            }
        ).ToListAsync();
    }
}