using Microsoft.EntityFrameworkCore;
using SystemBase.Models;
using SystemBase.Services.IServices;

namespace SystemBase.Data;

public class AplicationDbContext : DbContext
{
    private readonly IPasswordHasher _passwordHasher;

    public AplicationDbContext(DbContextOptions<AplicationDbContext> options, IPasswordHasher passwordHasher) :
        base(options)
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
        modelBuilder.Entity<users>(entity =>
        {
            //definimos primarykey
            entity.HasKey(u => u.id);
            entity.Property(u => u.imageUser).HasMaxLength(500);
            entity.Property(u => u.userName).IsRequired().HasMaxLength(255);
            entity.Property(u => u.password).IsRequired().HasMaxLength(500);
            entity.Property(u => u.name).IsRequired().HasMaxLength(50);
            entity.Property(u => u.app).HasMaxLength(50);
            entity.Property(u => u.apm).HasMaxLength(50);
            entity.Property(u => u.created).IsRequired();
            entity.Property(u => u.status).HasDefaultValue(true);
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

        /* ========================== NOMBRE A LA REGLAS DE ACCESO AL USUARIO ======================================*/
        modelBuilder.Entity<nameRule>(entity =>
        {
            entity.HasKey(r => r.id);
            entity.Property(r => r.name).IsRequired().HasMaxLength(50);
        });
        modelBuilder.Entity<nameRule>().HasData(
            new
            {
                id = 1,
                name = "Acceso de CEO",
            }
        );

        /* ========================== REGLAS DEFINIDAS PARA EL ACCESS TOKEN ======================================*/
        modelBuilder.Entity<endpointAccess>(entity => { entity.HasKey(r => r.id); });
        modelBuilder.Entity<endpointAccess>().HasData(
            new
            {
                id = 1,
                endpoint = "/auth/logout",
                method = "POST",
                permission = "auth.logout.self",
                status = true
            },
            new
            {
                id = 2,
                endpoint = "/auth/logout",
                method = "POST",
                permission = "auth.logout.*",
                status = true
            },
            new
            {
                id = 3,
                endpoint = "/auth/logout",
                method = "POST",
                permission = "auth.logout.subordinate",
                status = true
            }
        );

        /* ========================== ASIGNACION DE UNA REGLA Y LOS ACCESOS A LOS ENDPOINT PARA EL ACCESS TOKEN ======================================*/
        modelBuilder.Entity<EndpointAccessNameRule>(entity =>
        {
            entity.HasKey(r => r.id);
            entity.HasOne(r => r.endpointAccess)
                .WithMany()
                .HasForeignKey(r => r.idEndpointAccess)
                .IsRequired();
            entity.HasOne(r => r.nameRule)
                .WithMany()
                .HasForeignKey(r => r.idNameRule)
                .IsRequired();
        });

        modelBuilder.Entity<EndpointAccessNameRule>().HasData(
            new
            {
                id = 1,
                idEndpointAccess = 1,
                idNameRule = 1,
            },
            new
            {
                id = 2,
                idEndpointAccess = 2,
                idNameRule = 1,
            }
        );


        modelBuilder.Entity<roles>(entity =>
        {
            entity.HasKey(r => r.id);
            entity.Property(r => r.name).IsRequired().HasMaxLength(50);
            entity.HasOne(r => r.endpointAccessNameRule)
                .WithMany()
                .HasForeignKey(r => r.idEndpointAccessNameRule);
        });
        modelBuilder.Entity<roles>().HasData(
            new
            {
                id = 1,
                name = "CEO",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)),
                code = roleCode.Director,
                idEndpointAccessNameRule = 1,
            },
            new
            {
                id = 2,
                name = "Gerente de Nave",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)),
                code = roleCode.Gerente,
            }
        );

        /* ================================== ASIGNACION DE USUARIO A UN ROLE =============================================*/
        modelBuilder.Entity<user_assignments>(entity =>
        {
            entity.HasKey(uax => uax.id);
            entity.Property(uax => uax.scopeType).HasConversion<string>();
            entity.Property(uax => uax.created).IsRequired();
            entity.Property(uax => uax.isActive).IsRequired().HasDefaultValue(true);
            //Es para garantizar que el dato es unico pero toma en cuenta que la combinación.
            entity.HasIndex(uax => new { uax.scopeId, uax.scopeType, uax.idUser, uax.idRole }).IsUnique();
            entity.HasOne(uax => uax.users).WithMany()
                .HasForeignKey(uax => uax.idUser).IsRequired();
            //verifica si necesitas eliminacion en cascada !! - .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(uax => uax.roles).WithMany()
                .HasForeignKey(uax => uax.idRole).IsRequired(); //en modo desarrollo temporramlmente no lo requiero  
        });
        modelBuilder.Entity<user_assignments>().HasData(
            new
            {
                id = 1,
                idUser = 1,
                codeEmployee = "N1-12",
                idRole = 1,
                scopeType = scopeType.COMPANY,
                scopeId = (int?)null,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            }
        );

        /*============================== REFRESH TOKENS =========================================*/
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