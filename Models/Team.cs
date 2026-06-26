namespace SystemBase.Models;

// Catálogo global de equipos (se contextualiza vía CampusAreaWorkShiftTeam).
public class Team
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public DateTimeOffset created { get; set; }
}