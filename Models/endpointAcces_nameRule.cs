namespace SystemBase.Models;

public class EndpointAccessNameRule
{
    public int id { get; set; }
    public int idEndpointAccess { get; set; }
    public int idNameRule { get; set; }
    public int idRole { get; set; }
    public nameRule nameRule { get; set; } = null!;
    public endpointAccess endpointAccess { get; set; } = null!;
    public Roles roles { get; set; } = null!;
}