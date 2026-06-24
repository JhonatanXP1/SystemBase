namespace SystemBase.Models;

// Puente N:M campusArea <-> workShift. Destino del scope `campus_area_workdate`.
public class CampusAreaWorkShift
{
    public int id { get; set; }
    public int idCampusArea { get; set; }
    public int idWorkShift { get; set; }
    public DateTimeOffset created { get; set; }

    public CampusArea? campusArea { get; set; }
    public WorkShift? workShift { get; set; }
}
