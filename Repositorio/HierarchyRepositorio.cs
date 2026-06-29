using Microsoft.EntityFrameworkCore;
using SystemBase.Data;
using SystemBase.Models;
using SystemBase.Repositorio.IRepositorio;
using ScopeType = SystemBase.Models.ScopeType;

namespace SystemBase.Repositorio;


public class HierarchyRepositorio(AplicationDbContext dbContext):IHierarchyRepositorio
{
    private readonly AplicationDbContext _db = dbContext;

    // Devuelve el código del rol del solicitante en el scope dado, o null si no tiene asignación
    // (o falta el usuario / el scope es inválido). El null significa "sin acceso".
    public async Task<RoleCode?> GetFilterHierarchy(int? idUser, string scopeName, int? scopeId)
    {
        if (idUser is null || !Enum.TryParse<ScopeType>(scopeName, out var scope))
            return null;

        // Se castea a RoleCode? para distinguir "no encontrado" (null) de un código real.
        return await (
            from ua in _db.userAssignments
            join r in _db.roles on ua.idRole equals r.id
            where ua.idUser == idUser
                  && ua.scopeId == scopeId
                  && ua.scopeType == scope
            select (RoleCode?)r.code
        ).FirstOrDefaultAsync();
    }
}