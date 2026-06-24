using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

public static class UserAssignmentsSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserAssignments>().HasData(
            new
            {
                id = 1,
                idUser = 1,
                codeEmployee = "CEO-01",
                idRole = 1,
                scopeType = scopeType.company,
                scopeId = (int?)1,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 2,
                idUser = 2,
                codeEmployee = "GG-01",
                idRole = 2,
                scopeType = scopeType.company_area,
                scopeId = (int?)1,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 3,
                idUser = 3,
                codeEmployee = "GG-02",
                idRole = 2,
                scopeType = scopeType.company_area,
                scopeId = (int?)1,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 4,
                idUser = 4,
                codeEmployee = "GRH-01",
                idRole = 3,
                scopeType = scopeType.company_area,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 5,
                idUser = 5,
                codeEmployee = "SUP-01",
                idRole = 4,
                scopeType = scopeType.company_area_workdate,
                scopeId = (int?)1,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 6,
                idUser = 6,
                codeEmployee = "SUP-02",
                idRole = 4,
                scopeType = scopeType.company_area_workdate,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 7,
                idUser = 7,
                codeEmployee = "COORD-01",
                idRole = 5,
                scopeType = scopeType.team,
                scopeId = (int?)1,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 8,
                idUser = 8,
                codeEmployee = "COORD-02",
                idRole = 5,
                scopeType = scopeType.team,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 10,
                idUser = 10,
                codeEmployee = "OP-01",
                idRole = 6,
                scopeType = scopeType.team,
                scopeId = (int?)1,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 11,
                idUser = 11,
                codeEmployee = "OP-02",
                idRole = 6,
                scopeType = scopeType.team,
                scopeId = (int?)1,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 12,
                idUser = 12,
                codeEmployee = "ALM-01",
                idRole = 7,
                scopeType = scopeType.team,
                scopeId = (int?)1,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 13,
                idUser = 13,
                codeEmployee = "LIMP-01",
                idRole = 8,
                scopeType = scopeType.team,
                scopeId = (int?)1,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 14,
                idUser = 14,
                codeEmployee = "OP-03",
                idRole = 6,
                scopeType = scopeType.team,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 15,
                idUser = 15,
                codeEmployee = "ALM-02",
                idRole = 7,
                scopeType = scopeType.team,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 16,
                idUser = 16,
                codeEmployee = "ALM-03",
                idRole = 7,
                scopeType = scopeType.team,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 17,
                idUser = 17,
                codeEmployee = "LIMP-02",
                idRole = 8,
                scopeType = scopeType.team,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 18,
                idUser = 18,
                codeEmployee = "LIMP-03",
                idRole = 8,
                scopeType = scopeType.team,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            }
        );
    }
}
