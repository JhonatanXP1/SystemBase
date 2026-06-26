using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

// 7 anclas team-en-contexto. Destino del scopeType.team (coordinadores y empleados).
// Mismo team del catálogo puede aparecer en varios turnos (ej. PROD-A1 en Mañana y Tarde).
public static class CampusAreaWorkShiftTeamSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6));
        modelBuilder.Entity<CampusAreaWorkShiftTeam>().HasData(
            new { id = 1, idCampusAreaWorkShift = 1, idTeam = 1, created }, // PROD-A1 en Producción Mañana
            new { id = 2, idCampusAreaWorkShift = 2, idTeam = 1, created }, // PROD-A1 en Producción Tarde
            new { id = 3, idCampusAreaWorkShift = 1, idTeam = 2, created }, // PROD-A2 en Producción Mañana
            new { id = 4, idCampusAreaWorkShift = 3, idTeam = 3, created }, // ALM-A1 en Almacén Mañana
            new { id = 5, idCampusAreaWorkShift = 4, idTeam = 3, created }, // ALM-A1 en Almacén Tarde
            new { id = 6, idCampusAreaWorkShift = 4, idTeam = 4, created }, // ALM-A2 en Almacén Tarde
            new { id = 7, idCampusAreaWorkShift = 5, idTeam = 5, created }  // LIMP-A1 en Limpieza Mañana
        );
    }
}
