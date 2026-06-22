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

    private sealed record UserRoleRow(Users u, Roles? r);

    private IQueryable<UserRoleRow> GetQueryUniversal(HierarchyFilter? filter)
    {
        var query =
            from u in _db.users.AsNoTracking()
            join ua in _db.userAssignments on u.id equals ua.idUser
            join r in _db.roles on ua.idRole equals r.id into roleGroup
            from r in roleGroup.DefaultIfEmpty()
            select new UserRoleRow(u, r);
        
        if (filter != null) // si viene null posiblemente sea un reporte.
        {
            if (filter.levelRole.HasValue)
                query = query.Where(x => x.r != null && (int)x.r.code > filter.levelRole.Value);

            if (filter.idsExcepcion is { Count: > 0 })
                query = query.Where(x => !filter.idsExcepcion.Contains(x.u.id));
            if (filter.isActive.HasValue)
                query = query.Where(x => x.u.status == filter.isActive.Value);
            
            if (filter.isDeleted.HasValue)
            {
                query = filter.isDeleted.Value ? query.Where(x => x.u.deleteAt != null) : // Está eliminado
                    query.Where(x => x.u.deleteAt == null); // No está eliminado
            }

            if (filter.page.HasValue && filter.pageSize.HasValue)
            {
                query = query.OrderBy(x => x.u.id);
                int offset = (filter.page.Value - 1) * filter.pageSize.Value; // Es offSet para la paginación.
                query = query.Skip(offset).Take(filter.pageSize.Value);
            }

        }

        return query;
    }

    public async Task<List<userDashboardDTO>> GetAllUsers(HierarchyFilter? filter)
    {
        var query = GetQueryUniversal(filter);
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

    public Task<int> GetUsersCountAsync(HierarchyFilter? filter)
    {
        if (filter != null)
        {
            if (filter.page.HasValue)
                filter.page = null;
            if (filter.pageSize.HasValue)
                filter.pageSize = null;
        }

        return GetQueryUniversal(filter).CountAsync();
    }
}