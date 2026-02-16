using Microsoft.EntityFrameworkCore;
using SystemBase.Models;
using SystemBase.Services.IServices;

namespace SystemBase.Data;

public class AplicationDbContext : DbContext
{
    private readonly IPasswordHasher _passwordHasher;
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options, IPasswordHasher passwordHasher) : base(options)
    {
        _passwordHasher = passwordHasher;
    }

    public DbSet<users> users { get; set; }
    public DbSet<roles> roles { get; set; }
    public DbSet<refreshTokens> refreshTokens { get; set; }
    public DbSet<user_assignments> user_assignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<users>(users =>
        {
            //definimos primarykey
            users.HasKey(u => u.id);
            users.Property(u => u.imageUser).HasMaxLength(500);
            users.Property(u => u.userName).IsRequired().HasMaxLength(255);
            users.Property(u => u.password).IsRequired().HasMaxLength(500);
            users.Property(u => u.name).IsRequired().HasMaxLength(50);
            users.Property(u => u.app).HasMaxLength(50);
            users.Property(u => u.apm).HasMaxLength(50);
            users.Property(u => u.created).IsRequired();
            users.Property(u => u.status).HasDefaultValue(true);
        });
        modelBuilder.Entity<users>().HasData(
            new
            {
                id = 1,
                userName = "@adminDev",
                password = _passwordHasher.Hash("Jhonatan11+"),
                name = "Jhonatan",
                app = "Diaz",
                apm = "Mendez",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            }
        );


        modelBuilder.Entity<roles>(roles =>
        {
            roles.HasKey(r => r.id);
            roles.Property(r => r.name).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<user_assignments>(ua =>
        {
            ua.HasKey(uax => uax.id);
            ua.Property(uax => uax.scopeType).HasConversion<string>().IsRequired();
            ua.Property(uax => uax.created).IsRequired();
            //Es para garantizar que el dato es unico pero toma en cuenta que la combinación.
            ua.HasIndex(uax => new { uax.scopeId, uax.scopeType, uax.idUser, uax.idRole }).IsUnique();
            ua.HasOne(uax => uax.users).WithMany()
                .HasForeignKey(uax => uax.idUser).IsRequired();
            //verifica si necesitas eliminacion en cascada !! - .OnDelete(DeleteBehavior.Cascade);
            ua.HasOne(uax => uax.roles).WithMany()
                .HasForeignKey(uax => uax.idRole).IsRequired();
        });

        modelBuilder.Entity<refreshTokens>(rT =>
        {
            rT.HasKey(rt => rt.id);
            rT.HasOne(rt => rt.User)
                .WithMany().HasForeignKey(rt => rt.idUser).IsRequired();
            rT.Property(rt => rt.createdAt).IsRequired();
            rT.Property(rt => rt.expiresAt).IsRequired();
        });
    }
}