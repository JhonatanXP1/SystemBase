using SystemBase.Models;

namespace SystemBase.Services.IServices;

public interface IHierarchyValidator
{
    HierarchyFilter? GenerateFilltersBasic(bool? isActive, bool? isDeleted, int? page, int? pageSize);
}