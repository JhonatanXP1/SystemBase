namespace SystemBase.Models;

// Puente N:M companyArea <-> workShift. Destino del scope `company_area_workdate`.
public class CompanyAreaWorkShift
{
    public int id { get; set; }
    public int idCompanyArea { get; set; }
    public int idWorkShift { get; set; }
    public DateTimeOffset created { get; set; }

    public CompanyArea? companyArea { get; set; }
    public WorkShift? workShift { get; set; }
}
