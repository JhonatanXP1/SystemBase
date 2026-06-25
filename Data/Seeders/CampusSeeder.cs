using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

public static class CampusSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campus>().HasData(
            new
            {
                id = 1,
                idCompany = 1,
                code = CampusCode.Sede,
                name = "Matriz Principal Puebla",
                direccion = "Carretera Puebla-Tlaxcala Km 5, Texmelucan, Pue.",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            }
        );
    }
}
