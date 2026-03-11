namespace SystemBase.Models;

public class endpointAcces_nameRule
{
    public int id {get;set;}
    public int idEndpointAccess {get;set;}
    public int idNameRule {get;set;}
    public nameRule NameRule {get;set;}
    public endpointAccess endpointAccess {get;set;}
}