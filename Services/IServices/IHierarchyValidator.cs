using SystemBase.Models;

namespace SystemBase.Services.IServices;

public interface IHierarchyValidator
{
    Task<HierarchyFilter?> GenerateFilltersBasic(bool? isActive, bool? isDeleted, int? page, int? pageSize);
}