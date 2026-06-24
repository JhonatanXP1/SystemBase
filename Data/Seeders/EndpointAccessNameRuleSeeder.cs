using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

public static class EndpointAccessNameRuleSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EndpointAccessNameRule>().HasData(
            new
            {
                id = 1,
                idEndpointAccess = 1,
                idNameRule = 1
            },
            new
            {
                id = 2,
                idEndpointAccess = 3,
                idNameRule = 1
            },
            new
            {
                id = 3,
                idEndpointAccess = 6,
                idNameRule = 1
            },
            // CEO (idNameRule = 1): acceso total ('*') a la gestión de usuarios
            new { id = 4, idEndpointAccess = 10, idNameRule = 1 },
            new { id = 5, idEndpointAccess = 11, idNameRule = 1 },
            new { id = 6, idEndpointAccess = 14, idNameRule = 1 },
            new { id = 7, idEndpointAccess = 15, idNameRule = 1 },
            new { id = 8, idEndpointAccess = 16, idNameRule = 1 },
            new { id = 9, idEndpointAccess = 17, idNameRule = 1 },
            new { id = 10, idEndpointAccess = 18, idNameRule = 1 },
            new { id = 11, idEndpointAccess = 20, idNameRule = 1 },
            new { id = 12, idEndpointAccess = 23, idNameRule = 1 },
            // Gerente General (idNameRule = 2): acceso total ('*') dentro de su company_area
            new { id = 13, idEndpointAccess = 1, idNameRule = 2 },
            new { id = 14, idEndpointAccess = 3, idNameRule = 2 },
            new { id = 15, idEndpointAccess = 6, idNameRule = 2 },
            new { id = 16, idEndpointAccess = 10, idNameRule = 2 },
            new { id = 17, idEndpointAccess = 11, idNameRule = 2 },
            new { id = 18, idEndpointAccess = 14, idNameRule = 2 },
            new { id = 19, idEndpointAccess = 15, idNameRule = 2 },
            new { id = 20, idEndpointAccess = 16, idNameRule = 2 },
            new { id = 21, idEndpointAccess = 17, idNameRule = 2 },
            new { id = 22, idEndpointAccess = 18, idNameRule = 2 },
            new { id = 23, idEndpointAccess = 20, idNameRule = 2 },
            new { id = 24, idEndpointAccess = 23, idNameRule = 2 },
            // Supervisor (idNameRule = 3): subordinate en read/update/assignment.read, self en password
            new { id = 25, idEndpointAccess = 2, idNameRule = 3 },
            new { id = 26, idEndpointAccess = 4, idNameRule = 3 },
            new { id = 27, idEndpointAccess = 7, idNameRule = 3 },
            new { id = 28, idEndpointAccess = 9, idNameRule = 3 },
            new { id = 29, idEndpointAccess = 13, idNameRule = 3 },
            new { id = 30, idEndpointAccess = 22, idNameRule = 3 },
            new { id = 31, idEndpointAccess = 19, idNameRule = 3 },
            // Coordinador (idNameRule = 4): subordinate en read, self en update/assignment.read/password
            new { id = 32, idEndpointAccess = 2, idNameRule = 4 },
            new { id = 33, idEndpointAccess = 4, idNameRule = 4 },
            new { id = 34, idEndpointAccess = 7, idNameRule = 4 },
            new { id = 35, idEndpointAccess = 9, idNameRule = 4 },
            new { id = 36, idEndpointAccess = 12, idNameRule = 4 },
            new { id = 37, idEndpointAccess = 21, idNameRule = 4 },
            new { id = 38, idEndpointAccess = 19, idNameRule = 4 },
            // Empleado (idNameRule = 5): self en todo
            new { id = 39, idEndpointAccess = 24, idNameRule = 5 },
            new { id = 40, idEndpointAccess = 25, idNameRule = 5 },
            new { id = 41, idEndpointAccess = 5, idNameRule = 5 },
            new { id = 42, idEndpointAccess = 8, idNameRule = 5 },
            new { id = 43, idEndpointAccess = 12, idNameRule = 5 },
            new { id = 44, idEndpointAccess = 21, idNameRule = 5 },
            new { id = 45, idEndpointAccess = 19, idNameRule = 5 }
        );
    }
}