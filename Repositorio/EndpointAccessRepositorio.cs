using Microsoft.EntityFrameworkCore;
using SystemBase.Data;
using SystemBase.Repositorio.IRepositorio;

namespace SystemBase.Repositorio;

public class EndpointAccessRepositorio (AplicationDbContext db):IEndpointAccessRepositorio
{
    private readonly AplicationDbContext _db = db;

    public async Task<List<string>> GetEndpoints(int idUserAssigments)
    {
        return await (
            from ua in _db.userAssignments
            join ean in _db.endpointAccessNameRules on ua.idRole equals ean.idRole
            join e in _db.endpointAccess on ean.idEndpointAccess equals e.id
            where ua.id == idUserAssigments && ua.isActive && e.status
            select e.permission
        ).Distinct().ToListAsync();
    }
}