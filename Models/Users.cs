namespace SystemBase.Models;

public class Users
{
    public Users(string userName, string password, string name)
    {
        this.userName = userName;
        this.password = password;
        this.name = name;
        status = true;
    }
    public int id { get; set; }
    public string? imageUser { get; set; }
    public string userName { get; set; }
    public string password {get; set;}
    public string name { get; set;}
    public string? app {get; set; }
    public string? apm {get; set; } 
    public DateTimeOffset created { get; set;}
    public bool status { get; set; }
    
}