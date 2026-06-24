using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

public static class RolesSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Roles>().HasData(
            new
            {
                id = 1,
                name = "CEO",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)),
                code = RoleCode.Director,
                idNameRule = 1
            },
            new
            {
                id = 2,
                name = "Gerente General",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)),
                code = RoleCode.Gerente,
                idNameRule = 2
            },
            new
            {
                id = 3,
                name = "Gerente RH",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)),
                code = RoleCode.Gerente,
                idNameRule = 2
            },
            new
            {
                id = 4,
                name = "Supervisor",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)),
                code = RoleCode.Supervisor,
                idNameRule = 3
            },
            new
            {
                id = 5,
                name = "Coordinador",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)),
                code = RoleCode.Coordinador,
                idNameRule = 4
            },
            new
            {
                id = 6,
                name = "Operador de producción",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)),
                code = RoleCode.Empleado,
                idNameRule = 5
            },
            new
            {
                id = 7,
                name = "Auxiliar de almacén",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)),
                code = RoleCode.Empleado,
                idNameRule = 5
            },
            new
            {
                id = 8,
                name = "Personal de limpieza industrial",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)),
                code = RoleCode.Empleado,
                idNameRule = 5
            }
        );
    }
}