namespace SystemBase.Models;

public class user_assignments
{
    public int id { get; set; }
    public int idUser {get;set;}
    public int idRole {get;set;}
    public scopeType scopeType {get;set;}
    public int scopeId {get;set;}
    public DateTime created {get;set;}
    public roles roles {get;set;}
    public users users {get;set;}
}