using Microsoft.EntityFrameworkCore;
using SystemBase.Models;
using SystemBase.Services.IServices;

namespace SystemBase.Data.Seeders;

public static class UsersSeeder
{
    public static void Seed(ModelBuilder modelBuilder, IPasswordHasher passwordHasher)
    {
        modelBuilder.Entity<Users>().HasData(
            new
            {
                id = 1,
                imageUser ="public/profile/loise.png",
                userName = "lois@orbita360.com",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Lois",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 2,
                userName = "@hal",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Hal",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 3,
                userName = "@francis",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Francis",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 4,
                imageUser ="public/profile/craig.png",
                userName = "@craig",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Craig",
                app = "Feldspar",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 5,
                userName = "@malcolm",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Malcolm",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 6,
                imageUser ="public/profile/steve.png",
                userName = "@stevie",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Stevie",
                app = "Kenarban",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 7,
                imageUser ="public/profile/reese.png",
                userName = "@reese",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Reese",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 8,
                userName = "@dewey",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Dewey",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 10,
                userName = "@lloyd",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Lloyd",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 11,
                userName = "@dabney",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Dabney",
                app = "Hooper",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 12,
                userName = "@kevin",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Kevin",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 13,
                userName = "@cynthia",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Cynthia",
                app = "Sanders",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 14,
                userName = "@davidh",
                password = passwordHasher.Hash("Temporal123+"),
                name = "David",
                app = "Hanson",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 15,
                userName = "@chad",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Chad",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 16,
                userName = "@davey",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Davey",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 17,
                userName = "@zoe",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Zoe",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 18,
                userName = "@penelope",
                password = passwordHasher.Hash("Temporal123+"),
                name = "Penelope",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            }
        );
    }
}