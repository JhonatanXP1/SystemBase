using SystemBase.Models.ReadModels;

namespace SystemBase.Models.DTO;

public class UsersDashboardDto
{
    public List<UserDashboardRow>? users { get; set; }
    public int? totalRecords { get; set; }
    public int? page { get; set; }
    public int? pageSize { get; set; }
}