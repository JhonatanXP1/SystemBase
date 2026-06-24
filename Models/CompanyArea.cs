namespace SystemBase.Models;

// Puente N:M company <-> area. Destino del scope `company_area`.
public class CompanyArea
{
    public int id { get; set; }
    public int idCompany { get; set; }
    public int idArea { get; set; }
    public DateTimeOffset created { get; set; }

    public Company? company { get; set; }
    public Area? area { get; set; }
}
