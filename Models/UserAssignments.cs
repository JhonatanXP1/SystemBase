namespace SystemBase.Models;

public class UserAssignments
{
    public UserAssignments(int id, int idUser, string? codeEmployee, int idRole, scopeType scopeType, int? scopeId, DateTimeOffset created, bool isActive, Roles roles, Users users)
    {
        this.id = id;
        this.idUser = idUser;
        this.codeEmployee = codeEmployee;
        this.idRole = idRole;
        this.scopeType = scopeType;
        this.scopeId = scopeId;
        this.created = created;
        this.isActive = isActive;
        this.roles = roles;
        this.users = users;
    }

    public int id { get; set; }
    public int idUser {get;set;}
    public string? codeEmployee { get; set; }
    public int idRole {get;set;}
    public scopeType scopeType {get;set;}
    public int? scopeId {get;set;}
    public DateTimeOffset created {get;set;}
    public bool isActive {get;set;}
    public Roles roles {get;set;}
    public Users users {get;set;} 
}