using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data.Seeders;

public static class TeamSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>().HasData(
            new { id = 1, name = "PROD-A1", created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)) },
            new { id = 2, name = "PROD-A2", created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)) },
            new { id = 3, name = "ALM-A1", created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)) },
            new { id = 4, name = "ALM-A2", created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)) },
            new { id = 5, name = "LIMP-A1", created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)) }
        );
    }
}
