namespace SystemBase.Models;

// Puente N:M campusArea <-> shift. Destino del scope `shift`.
public class CampusAreaShift
{
    public int id { get; set; }
    public int idCampusArea { get; set; }
    public int idShift { get; set; }
    public DateTimeOffset created { get; set; }

    public CampusArea? campusArea { get; set; }
    public Shift? shift { get; set; }
}
