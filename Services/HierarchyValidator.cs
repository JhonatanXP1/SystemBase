using SystemBase.Models;
using SystemBase.Services.IServices;

namespace SystemBase.Services;

public class HierarchyValidator(IRequestContext requestContext ) : IHierarchyValidator
{
    private readonly IRequestContext _requestContext = requestContext;
    public HierarchyFilter? GenerateFilltersBasic(bool? isActive, bool? isDeleted, int? page, int? pageSize)
    {
        if (isActive.HasValue || isDeleted.HasValue || page.HasValue || pageSize.HasValue)
        {
            var filter = new HierarchyFilter(null);

            if (isActive.HasValue)
                filter.isActive = isActive;
            if (isDeleted.HasValue)
                filter.isDeleted = isDeleted;
            if (page.HasValue)
                filter.page = page.Value;
            if (pageSize.HasValue)
                filter.pageSize = pageSize.Value;
            return filter;
        }
        
        return null;
    }

    public IQueryable<Roles> Hierarchy()
    {
        
        
        return null;
    }
    
}