using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

// Asignaciones de usuarios al árbol organizacional de Órbita 360 (Matriz Principal Puebla).
// scopeId apunta ahora a filas reales de los puentes Campus* (ya no placeholders).
public static class UserAssignmentsSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6));
        modelBuilder.Entity<UserAssignments>().HasData(
            // CEO
            new { id = 1, idUser = 1, codeEmployee = "CEO-01", idRole = 1, scopeType = scopeType.company, scopeId = (int?)1, isActive = true, created },

            // Gerentes Generales (de Sede) — ambos anclan al campus completo
            new { id = 2, idUser = 2, codeEmployee = "GG-01", idRole = 2, scopeType = scopeType.campus, scopeId = (int?)1, isActive = true, created },
            new { id = 3, idUser = 3, codeEmployee = "GG-02", idRole = 2, scopeType = scopeType.campus, scopeId = (int?)1, isActive = true, created },

            // Gerente RH — ancla al área RH
            new { id = 4, idUser = 4, codeEmployee = "GRH-01", idRole = 3, scopeType = scopeType.area, scopeId = (int?)2, isActive = true, created },

            // Supervisores — Malcolm Almacén, Stevie Limpieza (ya no son supervisores de turno)
            new { id = 5, idUser = 5, codeEmployee = "SUP-01", idRole = 4, scopeType = scopeType.area, scopeId = (int?)3, isActive = true, created },
            new { id = 6, idUser = 6, codeEmployee = "SUP-02", idRole = 4, scopeType = scopeType.area, scopeId = (int?)4, isActive = true, created },

            // Coordinador Reese — toda Producción (anclas 1, 2, 3)
            new { id = 7, idUser = 7, codeEmployee = "COORD-01", idRole = 5, scopeType = scopeType.team, scopeId = (int?)1, isActive = true, created },
            new { id = 19, idUser = 7, codeEmployee = "COORD-01", idRole = 5, scopeType = scopeType.team, scopeId = (int?)2, isActive = true, created },
            new { id = 20, idUser = 7, codeEmployee = "COORD-01", idRole = 5, scopeType = scopeType.team, scopeId = (int?)3, isActive = true, created },

            // Coordinador Dewey — Almacén (4, 5, 6) + Limpieza (7)
            new { id = 8, idUser = 8, codeEmployee = "COORD-02", idRole = 5, scopeType = scopeType.team, scopeId = (int?)4, isActive = true, created },
            new { id = 21, idUser = 8, codeEmployee = "COORD-02", idRole = 5, scopeType = scopeType.team, scopeId = (int?)5, isActive = true, created },
            new { id = 22, idUser = 8, codeEmployee = "COORD-02", idRole = 5, scopeType = scopeType.team, scopeId = (int?)6, isActive = true, created },
            new { id = 23, idUser = 8, codeEmployee = "COORD-02", idRole = 5, scopeType = scopeType.team, scopeId = (int?)7, isActive = true, created },

            // Operativos de Producción
            new { id = 10, idUser = 10, codeEmployee = "OP-01", idRole = 6, scopeType = scopeType.team, scopeId = (int?)1, isActive = true, created }, // Lloyd     - PROD-A1 mañana
            new { id = 11, idUser = 11, codeEmployee = "OP-02", idRole = 6, scopeType = scopeType.team, scopeId = (int?)2, isActive = true, created }, // Dabney    - PROD-A1 tarde
            new { id = 14, idUser = 14, codeEmployee = "OP-03", idRole = 6, scopeType = scopeType.team, scopeId = (int?)3, isActive = true, created }, // D. Hanson - PROD-A2 mañana

            // Auxiliares de Almacén
            new { id = 12, idUser = 12, codeEmployee = "ALM-01", idRole = 7, scopeType = scopeType.team, scopeId = (int?)4, isActive = true, created }, // Kevin - ALM-A1 mañana
            new { id = 15, idUser = 15, codeEmployee = "ALM-02", idRole = 7, scopeType = scopeType.team, scopeId = (int?)5, isActive = true, created }, // Chad  - ALM-A1 tarde
            new { id = 16, idUser = 16, codeEmployee = "ALM-03", idRole = 7, scopeType = scopeType.team, scopeId = (int?)6, isActive = true, created }, // Davey - ALM-A2 tarde

            // Personal de Limpieza (las 3 en el mismo team LIMP-A1 mañana)
            new { id = 13, idUser = 13, codeEmployee = "LIMP-01", idRole = 8, scopeType = scopeType.team, scopeId = (int?)7, isActive = true, created }, // Cynthia
            new { id = 17, idUser = 17, codeEmployee = "LIMP-02", idRole = 8, scopeType = scopeType.team, scopeId = (int?)7, isActive = true, created }, // Zoe
            new { id = 18, idUser = 18, codeEmployee = "LIMP-03", idRole = 8, scopeType = scopeType.team, scopeId = (int?)7, isActive = true, created }  // Penelope
        );
    }
}
