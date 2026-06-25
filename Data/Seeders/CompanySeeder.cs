using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

public static class CompanySeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().HasData(
            new
            {
                id = 1,
                name = "Órbita 360",
                direccion = "Av. Independencia 200, Puebla, Pue.",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            }
        );
    }
}
