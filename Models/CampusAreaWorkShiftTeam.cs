namespace SystemBase.Models;

// Puente N:M campusAreaWorkShift <-> team (team en su contexto). Destino del scope `team`.
public class CampusAreaWorkShiftTeam
{
    public int id { get; set; }
    public int idCampusAreaWorkShift { get; set; }
    public int idTeam { get; set; }
    public DateTimeOffset created { get; set; }

    public CampusAreaWorkShift? campusAreaWorkShift { get; set; }
    public Team? team { get; set; }
}
