namespace SystemBase.Models;

// Catálogo global de turnos (reutilizable entre áreas vía CampusAreaShift).
public class Shift
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public TimeOnly hourInit { get; set; }
    public TimeOnly hourEnd { get; set; }
    public DateTimeOffset created { get; set; }
}
