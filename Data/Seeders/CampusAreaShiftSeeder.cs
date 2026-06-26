using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

// 5 puentes área-turno. Solo se siembran los puentes que necesitan los teams operativos
// (RH no tiene turnos visibles). scopeId destino para scopeType.shift (queda latente).
public static class CampusAreaShiftSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6));
        modelBuilder.Entity<CampusAreaShift>().HasData(
            new { id = 1, idCampusArea = 1, idShift = 1, created }, // Producción x Mañana
            new { id = 2, idCampusArea = 1, idShift = 2, created }, // Producción x Tarde
            new { id = 3, idCampusArea = 3, idShift = 1, created }, // Almacén x Mañana
            new { id = 4, idCampusArea = 3, idShift = 2, created }, // Almacén x Tarde
            new { id = 5, idCampusArea = 4, idShift = 1, created }  // Limpieza x Mañana
        );
    }
}
