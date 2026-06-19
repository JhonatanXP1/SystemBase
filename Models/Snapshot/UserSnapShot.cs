using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace SystemBase.Models.Snapshot;

public class userDashboardDTO
{
    public int id { get; set; }
    public string? imageUser { get; set; }
    public string name { get; set; }
    public string? app { get; set; }
    public string? apm { get; set; }
    public string userName { get; set; }
    public bool status { get; set; }
    public string? roleCode { get; set; }
    public string? roleName { get; set; }
}