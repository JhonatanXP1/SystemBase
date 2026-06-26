namespace SystemBase.Models;

// Puente N:M campusAreaShift <-> team (team en su contexto). Destino del scope `team`.
public class CampusAreaShiftTeam
{
    public int id { get; set; }
    public int idCampusAreaShift { get; set; }
    public int idTeam { get; set; }
    public DateTimeOffset created { get; set; }

    public CampusAreaShift? campusAreaShift { get; set; }
    public Team? team { get; set; }
}
