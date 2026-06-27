using Microsoft.EntityFrameworkCore;
using SystemBase.Data;
using SystemBase.Models;
using SystemBase.Repositorio.IRepositorio;
using ScopeType = SystemBase.Models.ScopeType;

namespace SystemBase.Repositorio;


public class HierarchyRepositorio(AplicationDbContext dbContext):IHierarchyRepositorio
{
    private readonly AplicationDbContext _db = dbContext;

    public async Task<IQueryable<Roles>> GetFilterHierarchy(int? idUser, string scopeName, int? scopeId)
    {
        var scope = Enum.Parse<ScopeType>(scopeName);

        var code = await (
            from ua in _db.userAssignments
            join r in _db.roles on ua.idRole equals r.id
            where ua.idUser == idUser
                  && ua.scopeId == scopeId
                  && ua.scopeType == scope
            select r.code
        ).FirstOrDefaultAsync();
        
        Console.WriteLine($"{code}");
        return _db.roles.Where(r => r.code > code);
    }
}