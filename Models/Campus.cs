namespace SystemBase.Models;

// La nave física. Pertenece a una Company (1:N) y de aquí cuelga el área (N:M vía CampusArea).
// code = nivel jerárquico fijo (interno); name = etiqueta personalizable que ve el usuario.
public class Campus
{
    public int id { get; set; }
    public int idCompany { get; set; }
    public CampusCode code { get; set; }
    public string name { get; set; } = null!;
    public string? direccion { get; set; }
    public DateTimeOffset created { get; set; }

    public Company? company { get; set; }
}
