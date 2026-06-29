using Microsoft.EntityFrameworkCore;
using SystemBase.Data;
using SystemBase.Models;
using SystemBase.Models.ReadModels;
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

    public async Task<List<UserDashboardRow>> GetAllUsers(HierarchyFilter? filter)
    {
        var query = ApplyPaging(GetQueryUniversal(filter), filter);
        return await query.Select(x => new UserDashboardRow(
            x.u.id,
            x.u.imageUser,
            x.u.name,
            x.u.app,
            x.u.apm,
            x.u.userName,
            x.u.status,
            x.r != null ? (int?)x.r.code : null,
            x.r != null ? x.r.name : null
        )).ToListAsync();
    }

    public Task<int> GetUsersCountAsync(HierarchyFilter? filter)
    {
        // Sin ApplyPaging: cuenta todas las filas que cumplen los filtros, no solo la página.
        return GetQueryUniversal(filter).CountAsync();
    }

    private IQueryable<UserRoleRow> GetQueryUniversal(HierarchyFilter? filter)
    {
        var query =
            from u in _db.users.AsNoTracking()
            join ua in _db.userAssignments on u.id equals ua.idUser
            join r in _db.roles on ua.idRole equals r.id into roleGroup
            from r in roleGroup.DefaultIfEmpty()
            select new UserRoleRow { u = u, r = r };

        if (filter != null) // si viene null posiblemente sea un reporte.
        {
            // Jerarquía: solo subordinados (code mayor). Sin nivel resuelto = sin acceso → nadie.
            if (filter.levelRole.HasValue)
                query = query.Where(x => x.r != null && (int)x.r.code > filter.levelRole.Value);
            else
                query = query.Where(_ => false);

            if (filter.idsExcepcion is { Count: > 0 })
                query = query.Where(x => !filter.idsExcepcion.Contains(x.u.id));
            if (filter.isActive.HasValue)
                query = query.Where(x => x.u.status == filter.isActive.Value);

            if (filter.isDeleted.HasValue)
                query = filter.isDeleted.Value
                    ? query.Where(x => x.u.deleteAt != null)
                    : // Está eliminado
                    query.Where(x => x.u.deleteAt == null); // No está eliminado
        }

        return query;
    }

    // La paginación se aplica aparte para que el Count pueda reutilizar los filtros sin Skip/Take.
    private IQueryable<UserRoleRow> ApplyPaging(IQueryable<UserRoleRow> query, HierarchyFilter? filter)
    {
        if (filter?.page is { } page && filter.pageSize is { } pageSize)
        {
            query = query.OrderBy(x => x.u.id);
            var offset = (page - 1) * pageSize; // Es offSet para la paginación.
            query = query.Skip(offset).Take(pageSize);
        }

        return query;
    }

    // Clase con object initializer (no constructor posicional): EF Core necesita "ver a través"
    // de la proyección para traducir los Where/OrderBy posteriores sobre x.u / x.r a SQL.
    private sealed class UserRoleRow
    {
        public Users u { get; set; } = null!;
        public Roles? r { get; set; }
    }
}