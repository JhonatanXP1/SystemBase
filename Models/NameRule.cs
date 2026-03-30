namespace SystemBase.Models;

public class NameRule
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;

    public ICollection<EndpointAccessNameRule> endpointAccessNameRules { get; set; } =
        new List<EndpointAccessNameRule>();

    public ICollection<Roles> roles { get; set; } = new List<Roles>();
}