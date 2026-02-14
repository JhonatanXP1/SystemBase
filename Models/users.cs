namespace SystemBase.Models;

public class users
{
    public users()
    {
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