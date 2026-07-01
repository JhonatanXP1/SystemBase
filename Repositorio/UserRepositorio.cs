using System.Text;
using Microsoft.EntityFrameworkCore;
using SystemBase.Data;
using SystemBase.Models;
using SystemBase.Models.ReadModels;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services;

namespace SystemBase.Repositorio;

public class UserRepositorio(AplicationDbContext db) : IUserRepositorio
{
    private readonly AplicationDbContext _db = db;
    // FROM + JOINs compartidos por el SELECT de datos y el COUNT.
    // INNER JOIN userAssignments (usuarios sin asignación quedan fuera) + LEFT JOIN roles.
    private const string FromAndJoins = """
                                        FROM users AS u
                                        INNER JOIN userAssignments AS ua ON u.id = ua.idUser
                                        LEFT  JOIN roles          AS r  ON ua.idRole = r.id
                                        """;

    public Task<string?> GetPasswordByIdAsync(int id)
    {
        return _db.users
            .Where(u => u.id == id)
            .Select(u => u.password)
            .FirstOrDefaultAsync();
    }

    public async Task<List<UserDashboardRow>> GetAllUsers(HierarchyFilter? filter, endpointUsers typeQuery) // 
    {
        var parameters = new List<object>();
        var where = BuildWhere(filter, parameters);

        // Los alias deben coincidir con los nombres del record UserDashboardRow
        // para que SqlQueryRaw mapee columna -> propiedad.
        var sql = new StringBuilder();
        sql.Append("""
                   SELECT u.id        AS id,
                          u.imageUser AS imageUser,
                          u.name      AS name,
                          u.app       AS app,
                          u.apm       AS apm,
                          u.userName  AS userName,
                          u.status    AS status
                   """);
        // totalAsig debe existir SIEMPRE como columna: el record lo espera y SqlQueryRaw
        // mapea por nombre. En el branch sin totales lo mandamos NULL para no romper el mapeo.
        sql.Append((int)typeQuery == 0
            ? ", COUNT(ua.id) AS totalAsig"
            : ", CAST(NULL AS int) AS totalAsig");
        sql.Append('\n').Append(FromAndJoins);
        sql.Append(where);

        if ((int)typeQuery == 0)
            sql.Append("\nGROUP BY u.id, u.imageUser, u.name, u.app, u.apm, u.userName, u.status");

        sql.Append("\nORDER BY u.id, u.name, u.app, u.apm");

        // Paginación SQL Server: OFFSET/FETCH (necesita ORDER BY, ya presente). Valores parametrizados.
        if (filter?.page is { } page && filter.pageSize is { } pageSize)
        {
            sql.Append($"\nOFFSET {{{parameters.Count}}} ROWS FETCH NEXT {{{parameters.Count + 1}}} ROWS ONLY");
            parameters.Add((page - 1) * pageSize); // offset
            parameters.Add(pageSize);
        }

        return await _db.Database
            .SqlQueryRaw<UserDashboardRow>(sql.ToString(), parameters.ToArray())
            .ToListAsync();
    }

    public async Task<int> GetUsersCountAsync(HierarchyFilter? filter, endpointUsers typeQuery)
    {
        // Sin paginación: cuenta todas las filas que cumplen los filtros, no solo la página.
        var parameters = new List<object>();
        var where = BuildWhere(filter, parameters);
        string count = "COUNT(*)";

        if ((int)typeQuery == 0)
        {
            count = "COUNT( DISTINCT u.id)";
        }

        var sql = $"SELECT {count} AS Value\n" + FromAndJoins + where;

        return await _db.Database
            .SqlQueryRaw<int>(sql, parameters.ToArray())
            .FirstAsync();
    }

    // Construye el WHERE dinámico y va agregando los valores a 'parameters' como {0},{1},...
    // filter == null => reporte: sin filtros (todas las filas).
    private static string BuildWhere(HierarchyFilter? filter, List<object> parameters)
    {
        if (filter is null)
            return string.Empty;

        var conditions = new List<string>();

        // Jerarquía: solo subordinados (code mayor). Sin nivel resuelto = sin acceso => nadie.
        if (filter.levelRole.HasValue)
        {
            // (subordinado con rol) OR (flag activo Y sin rol)
            var subordinados = $"(r.id IS NOT NULL AND r.code > {{{parameters.Count}}})";
            parameters.Add(filter.levelRole.Value);

            conditions.Add(filter.haveRole
                ? $"({subordinados} OR r.id IS NULL)"
                : subordinados);
        }
        else
        {
            conditions.Add("1 = 0"); // nadie
        }

        if (filter.idsExcepcion is { Count: > 0 })
        {
            var placeholders = string.Join(", ",
                filter.idsExcepcion.Select((_, i) => $"{{{parameters.Count + i}}}"));
            parameters.AddRange(filter.idsExcepcion.Cast<object>());
            conditions.Add($"u.id NOT IN ({placeholders})");
        }

        if (filter.isActive.HasValue)
        {
            conditions.Add($"u.status = {{{parameters.Count}}}");
            parameters.Add(filter.isActive.Value);
        }

        if (filter.isDeleted.HasValue)
            conditions.Add(filter.isDeleted.Value
                ? "u.deleteAt IS NOT NULL" // está eliminado
                : "u.deleteAt IS NULL"); // no está eliminado

        return conditions.Count > 0
            ? "\nWHERE " + string.Join("\n  AND ", conditions)
            : string.Empty;
    }
}