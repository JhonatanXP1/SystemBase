using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

public static class NameRuleSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NameRule>().HasData(
            new
            {
                id = 1,
                name = "Acceso de CEO"
            },
            new
            {
                id = 2,
                name = "Accesos de Gerente N-1"
            },
            new
            {
                id = 3,
                name = "Accesos de Supervisor"
            },
            new
            {
                id = 4,
                name = "Accesos de Coordinador"
            },
            new
            {
                id = 5,
                name = "Accesos de Empleado"
            }
        );
    }
}