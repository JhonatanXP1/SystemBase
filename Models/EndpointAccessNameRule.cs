namespace SystemBase.Models;

public class EndpointAccessNameRule
{
    public int id { get; set; }
    public int idEndpointAccess { get; set; }
    public int idNameRule { get; set; }
    public NameRule nameRule { get; set; } = null!;
    public endpointAccess endpointAccess { get; set; } = null!;
}