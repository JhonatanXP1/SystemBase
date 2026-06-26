using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

// 4 áreas en la única sede (Matriz Puebla).
// scopeId destino para scopeType.campus_area.
public static class CampusAreaSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6));
        modelBuilder.Entity<CampusArea>().HasData(
            new { id = 1, idCampus = 1, idArea = 1, created }, // Matriz Puebla x Producción
            new { id = 2, idCampus = 1, idArea = 2, created }, // Matriz Puebla x RH
            new { id = 3, idCampus = 1, idArea = 3, created }, // Matriz Puebla x Almacén
            new { id = 4, idCampus = 1, idArea = 4, created }  // Matriz Puebla x Limpieza
        );
    }
}
