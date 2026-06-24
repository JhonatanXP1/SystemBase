namespace SystemBase.Models;

// Puente N:M companyAreaWorkShift <-> team (team en su contexto). Destino del scope `team`.
public class CompanyAreaWorkShiftTeam
{
    public int id { get; set; }
    public int idCompanyAreaWorkShift { get; set; }
    public int idTeam { get; set; }
    public DateTimeOffset created { get; set; }

    public CompanyAreaWorkShift? companyAreaWorkShift { get; set; }
    public Team? team { get; set; }
}
