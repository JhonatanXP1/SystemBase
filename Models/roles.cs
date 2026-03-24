namespace SystemBase.Models;

public class Roles
{
    public int id { get; set; }

    //Es el tipos de Usuario predefenido por el sistema [Directo, Gerente, Supervisor, Cordinador, Empleado] Estatico. solo esos
    public RoleCode code { get; set; }
    public string name { get; set; } = string.Empty;
    public DateTimeOffset created { get; set; }

    public ICollection<EndpointAccessNameRule> endpointAccessNameRules { get; set; } =
        new List<EndpointAccessNameRule>();
}