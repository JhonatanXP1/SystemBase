namespace SystemBase.Models;

public class roles
{
    public int id { get; set; }
    //Es el tipos de Usuario predefenido por el sistema [Directo, Gerente, Supervisor, Cordinador, Empleado] Estatico. solo esos
    public roleCode code { get; set; }
    public string name { get; set; }
    public DateTimeOffset created { get; set; }
}