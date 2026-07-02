using SystemBase.Models;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services.IServices;

namespace SystemBase.Services;

public class HierarchyValidator(
    IRequestContext requestContext, 
    IHierarchyRepositorio hierarchyRepositorio
    ) : IHierarchyValidator
{
    private readonly IRequestContext _requestContext = requestContext;
    private readonly IHierarchyRepositorio _hierarchyRepositorio = hierarchyRepositorio;
    public async Task<HierarchyFilter?> GenerateFilltersBasic(bool? isActive, bool? isDeleted, int? page, int? pageSize)
    {
        // Código del rol del solicitante en su scope activo. null = sin acceso → el repo no devolverá usuarios.
        var code = await _hierarchyRepositorio.GetFilterHierarchy(
            _requestContext.userId, _requestContext.scopeName ?? "", _requestContext.scopeId);

        return new HierarchyFilter(null)
        {
            levelRole = (int?)code,
            scopeType = _requestContext.scopeName,
            scopeId = _requestContext.scopeId,
            isActive = isActive,
            isDeleted = isDeleted,
            page = page,
            pageSize = pageSize
        };
    }

}