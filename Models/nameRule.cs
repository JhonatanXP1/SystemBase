namespace SystemBase.Models;

public class nameRule
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;

    public ICollection<EndpointAccessNameRule> endpointAccessNameRules { get; set; } =
        new List<EndpointAccessNameRule>();
}