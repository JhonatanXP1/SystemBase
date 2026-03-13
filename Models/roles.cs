namespace SystemBase.Models;

public class roles
{
    public int id { get; set; }

    //Es el tipos de Usuario predefenido por el sistema [Directo, Gerente, Supervisor, Cordinador, Empleado] Estatico. solo esos
    public roleCode code { get; set; }
    public string name { get; set; } = string.Empty;
    public DateTimeOffset created { get; set; }
    public ICollection<EndpointAccessNameRule> endpointAccessNameRules { get; set; } = new List<EndpointAccessNameRule>();
}