namespace SystemBase.Models;

// Catálogo global de áreas (reutilizable entre empresas vía CompanyArea).
public class Area
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public string? code { get; set; }
    public DateTimeOffset created { get; set; }
}
