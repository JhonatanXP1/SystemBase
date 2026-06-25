using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

public static class AreaSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>().HasData(
            new { id = 1, name = "Producción", code = "PROD", created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)) },
            new { id = 2, name = "Recursos Humanos", code = "RH", created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)) },
            new { id = 3, name = "Almacén", code = "ALM", created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)) },
            new { id = 4, name = "Limpieza", code = "LIMP", created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)) }
        );
    }
}
