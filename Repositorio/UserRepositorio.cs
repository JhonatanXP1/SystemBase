using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SystemBase.Data;
using SystemBase.Models;
using SystemBase.Models.Snapshot;
using SystemBase.Repositorio.IRepositorio;

namespace SystemBase.Repositorio;

public class UserRepositorio(AplicationDbContext db) : IUserRepositorio
{
    private readonly AplicationDbContext _db = db;

    public Task<string?> GetPasswordByIdAsync(int id)
    {
        return _db.users
            .Where(u => u.id == id)
            .Select(u => u.password)
            .FirstOrDefaultAsync();
    }

    public async Task<List<userDashboardDTO>> GetAllUsers(HierarchyFilter? filter)
    {
        var query =
            from u in _db.users.AsNoTracking()
            join ua in _db.userAssignments on u.id equals ua.idUser
            join r in _db.roles on ua.idRole equals r.id into roleGroup
            from r in roleGroup.DefaultIfEmpty()
            select new { u, r };

        if (filter != null)
        {
            if (filter.levelRole.HasValue)
                query = query.Where(x => x.r != null && (int)x.r.code > filter.levelRole.Value);

            if (filter.idsExcepcion is { Count: > 0 })
                query = query.Where(x => !filter.idsExcepcion.Contains(x.u.id));
        }

        return await query.Select(x => new userDashboardDTO
        {
            id = x.u.id,
            imageUser = x.u.imageUser,
            name = x.u.name,
            app = x.u.app,
            apm = x.u.apm,
            userName = x.u.userName,
            status = x.u.status,
            roleCode = x.r != null ? x.r.code.ToString() : null,
            roleName = x.r != null ? x.r.name : null
        }).ToListAsync();
    }
}