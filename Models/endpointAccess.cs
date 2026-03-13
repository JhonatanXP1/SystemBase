namespace SystemBase.Models;

public class endpointAccess
{
    public int id {get;set;}
    public string endpoint {get;set;} = string.Empty;
    public string method {get;set;} = string.Empty;
    public string permission {get;set;} = string.Empty;
    public bool status {get;set;}
    public ICollection<EndpointAccessNameRule> endpointAccessNameRules { get; set; } = new List<EndpointAccessNameRule>();
}