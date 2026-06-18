namespace SystemBase.Models;

public class ProfileAccess
{
    public int id { get; set; }
    public int idRole { get; set; }
    public string profileTable { get; set; } = string.Empty;
    public bool canRead { get; set; }
    public bool canWrite { get; set; }
    public Roles roles { get; set; } = null!;
}