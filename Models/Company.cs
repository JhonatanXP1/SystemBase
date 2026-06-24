namespace SystemBase.Models;

// Catálogo: empresa (raíz de la jerarquía organizacional).
public class Company
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public string? direccion { get; set; }
    public DateTimeOffset created { get; set; }
}