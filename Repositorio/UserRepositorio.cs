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

    // Ruta aplanada de cada nodo de scope (dirección completa: company/campus/area/...).
    // Va como CTE al inicio del SQL, así no depende de una vista en la BD.
    private const string ScopePathCte = """
                                        WITH ScopePath AS (
                                            SELECT 'company' AS nodeType, c.id AS nodeId,
                                                   c.id AS companyId, CAST(NULL AS int) AS campusId,
                                                   CAST(NULL AS int) AS campusAreaId, CAST(NULL AS int) AS cawsId,
                                                   CAST(NULL AS int) AS teamNodeId
                                            FROM companies c
                                            UNION ALL
                                            SELECT 'campus', cp.id, cp.idCompany, cp.id, NULL, NULL, NULL
                                            FROM campuses cp
                                            UNION ALL
                                            SELECT 'campus_area', ca.id, cp.idCompany, ca.idCampus, ca.id, NULL, NULL
                                            FROM campusAreas ca
                                            JOIN campuses cp ON cp.id = ca.idCampus
                                            UNION ALL
                                            SELECT 'campus_area_workdate', caws.id, cp.idCompany, ca.idCampus, caws.idCampusArea, caws.id, NULL
                                            FROM campusAreaWorkShifts caws
                                            JOIN campusAreas ca ON ca.id = caws.idCampusArea
                                            JOIN campuses    cp ON cp.id = ca.idCampus
                                            UNION ALL
                                            SELECT 'team', cawst.id, cp.idCompany, ca.idCampus, caws.idCampusArea, cawst.idCampusAreaWorkShift, cawst.id
                                            FROM campusAreaWorkShiftTeams cawst
                                            JOIN campusAreaWorkShifts caws ON caws.id = cawst.idCampusAreaWorkShift
                                            JOIN campusAreas          ca   ON ca.id   = caws.idCampusArea
                                            JOIN campuses             cp   ON cp.id   = ca.idCampus
                                        )
                                        """;

    // Une cada asignación con su ruta aplanada. Solo se agrega cuando hay scope que filtrar.
    private const string ScopePathJoin =
        "\nJOIN ScopePath AS sp ON sp.nodeType = ua.scopeType AND sp.nodeId = ua.scopeId";

    // Traduce el nivel del solicitante a la columna de ScopePath por la que se filtra "hacia abajo".
    // El nombre de columna es constante (viene de un enum controlado), no hay inyección.
    private static string? ScopeColumn(string? scopeType) => scopeType switch
    {
        "company" => "sp.companyId",
        "campus" => "sp.campusId",
        "campus_area" => "sp.campusAreaId",
        "campus_area_workdate" => "sp.cawsId",
        "team" => "sp.teamNodeId",
        _ => null
    };

    // Hay filtro de rama si el solicitante trae un scope resuelto y mapeable.
    private static bool ScopeActive(HierarchyFilter? filter) =>
        filter?.scopeId is not null && ScopeColumn(filter.scopeType) is not null;

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
        var scopeActive = ScopeActive(filter);

        // Los alias deben coincidir con los nombres del record UserDashboardRow
        // para que SqlQueryRaw mapee columna -> propiedad.
        var sql = new StringBuilder();
        if (scopeActive) sql.Append(ScopePathCte).Append('\n');
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
        if (scopeActive) sql.Append(ScopePathJoin);
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
        var scopeActive = ScopeActive(filter);
        string count = "COUNT(*)";

        if ((int)typeQuery == 0)
        {
            count = "COUNT( DISTINCT u.id)";
        }

        var cte = scopeActive ? ScopePathCte + "\n" : "";
        var join = scopeActive ? ScopePathJoin : "";
        var sql = $"{cte}SELECT {count} AS Value\n" + FromAndJoins + join + where;

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

        // Scope: solo usuarios cuya rama cuelga del nodo del solicitante (hacia abajo).
        // Se suma (AND) a la jerarquía de rol. La columna la elige el nivel del solicitante.
        var scopeCol = ScopeColumn(filter.scopeType);
        if (scopeCol is not null && filter.scopeId.HasValue)
        {
            conditions.Add($"{scopeCol} = {{{parameters.Count}}}");
            parameters.Add(filter.scopeId.Value);
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