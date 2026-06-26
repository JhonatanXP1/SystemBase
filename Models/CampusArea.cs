namespace SystemBase.Models;

// Puente N:M campus <-> area (el área cuelga de la nave física). Destino del scope `area`.
public class CampusArea
{
    public int id { get; set; }
    public int idCampus { get; set; }
    public int idArea { get; set; }
    public DateTimeOffset created { get; set; }

    public Campus? campus { get; set; }
    public Area? area { get; set; }
}
