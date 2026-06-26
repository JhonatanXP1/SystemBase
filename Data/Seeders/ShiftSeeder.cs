using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

public static class ShiftSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shift>().HasData(
            new { id = 1, name = "Mañana", hourInit = new TimeOnly(6, 0), hourEnd = new TimeOnly(14, 0), created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)) },
            new { id = 2, name = "Tarde", hourInit = new TimeOnly(14, 0), hourEnd = new TimeOnly(22, 0), created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)) }
        );
    }
}
