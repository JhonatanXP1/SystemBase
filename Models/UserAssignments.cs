namespace SystemBase.Models;

public class UserAssignments
{
    public int id { get; set; }
    public int idUser { get; set; }
    public string? codeEmployee { get; set; } 
    public int idRole { get; set; }
    public scopeType scopeType { get; set; }
    public int? scopeId { get; set; }
    public DateTimeOffset created { get; set; }
    public bool isActive { get; set; }
    public Roles? roles { get; set; }
    public Users? users { get; set; }
}