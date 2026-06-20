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

    public DbSet<Users> users { get; set; }
    public DbSet<Roles> roles { get; set; }
    public DbSet<refreshTokens> refreshTokens { get; set; }
    public DbSet<UserAssignments> userAssignments { get; set; }
    public DbSet<NameRule> nameRules { get; set; }
    public DbSet<endpointAccess> endpointAccess { get; set; }
    public DbSet<EndpointAccessNameRule> endpointAccessNameRules { get; set; }
    public DbSet<ProfileAccess> profileAccess { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Users>(entity =>
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

        /* ========================== EMPRESA 1: NAVE INDUSTRIAL (Malcolm in the Middle) ============================*/
        modelBuilder.Entity<Users>().HasData(
            new
            {
                id = 1,
                userName = "@lois",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Lois",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 2,
                userName = "@hal",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Hal",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 3,
                userName = "@francis",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Francis",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 4,
                userName = "@craig",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Craig",
                app = "Feldspar",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 5,
                userName = "@malcolm",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Malcolm",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 6,
                userName = "@stevie",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Stevie",
                app = "Kenarban",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 7,
                userName = "@reese",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Reese",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 8,
                userName = "@dewey",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Dewey",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 10,
                userName = "@lloyd",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Lloyd",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 11,
                userName = "@dabney",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Dabney",
                app = "Hooper",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 12,
                userName = "@kevin",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Kevin",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 13,
                userName = "@cynthia",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Cynthia",
                app = "Sanders",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 14,
                userName = "@davidh",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "David",
                app = "Hanson",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 15,
                userName = "@chad",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Chad",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 16,
                userName = "@davey",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Davey",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 17,
                userName = "@zoe",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Zoe",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 18,
                userName = "@penelope",
                password = _passwordHasher.Hash("Temporal123+"),
                name = "Penelope",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            }
        );

        /* ========================== NOMBRE A LA REGLAS DE ACCESO AL USUARIO ======================================*/
        modelBuilder.Entity<NameRule>(entity =>
        {
            entity.HasKey(r => r.id);
            entity.Property(r => r.name).IsRequired().HasMaxLength(50);
        });
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

        /* ========================== REGLAS DEFINIDAS PARA EL ACCESS TOKEN ======================================*/
        modelBuilder.Entity<endpointAccess>(entity => { entity.HasKey(r => r.id); });
        modelBuilder.Entity<endpointAccess>().HasData(
            new
            {
                id = 1,
                endpoint = "/auth/logout",
                method = "POST",
                permission = "auth.logout.*",
                status = true
            },
            new
            {
                id = 2,
                endpoint = "/auth/logout",
                method = "POST",
                permission = "auth.logout.subordinate",
                status = true
            },
            new
            {
                id = 3,
                endpoint = "/auth/access",
                method = "GET",
                permission = "auth.access.*",
                status = true
            }
            ,
            new
            {
                id = 4,
                endpoint = "/auth/access",
                method = "GET",
                permission = "auth.access.subordinate",
                status = true
            },
            new
            {
                id = 5,
                endpoint = "/user",
                method = "GET",
                permission = "users.read.self",
                status = true
            },
            new
            {
                id = 6,
                endpoint = "/user",
                method = "GET",
                permission = "users.read.*",
                status = true
            },
            new
            {
                id = 7,
                endpoint = "/user",
                method = "GET",
                permission = "users.read.subordinate",
                status = true
            },
            new
            {
                id = 8,
                endpoint = "/user/{id}",
                method = "GET",
                permission = "users.read.self",
                status = true
            },
            new
            {
                id = 9,
                endpoint = "/user/{id}",
                method = "GET",
                permission = "users.read.subordinate",
                status = true
            },
            new
            {
                id = 10,
                endpoint = "/user/{id}",
                method = "GET",
                permission = "users.read.*",
                status = true
            },
            new
            {
                id = 11,
                endpoint = "/user",
                method = "POST",
                permission = "users.create.*",
                status = true
            },
            new
            {
                id = 12,
                endpoint = "/user/{id}",
                method = "PUT",
                permission = "users.update.self",
                status = true
            },
            new
            {
                id = 13,
                endpoint = "/user/{id}",
                method = "PUT",
                permission = "users.update.subordinate",
                status = true
            },
            new
            {
                id = 14,
                endpoint = "/user/{id}",
                method = "PUT",
                permission = "users.update.*",
                status = true
            },
            new
            {
                id = 15,
                endpoint = "/user/{id}",
                method = "DELETE",
                permission = "users.delete.*",
                status = true
            },
            new
            {
                id = 16,
                endpoint = "/user/{id}/status",
                method = "PATCH",
                permission = "users.status.*",
                status = true
            },
            new
            {
                id = 17,
                endpoint = "/user/{id}/assignment",
                method = "POST",
                permission = "users.assignment.create.*",
                status = true
            },
            new
            {
                id = 18,
                endpoint = "/user/{id}/assignment/{assignmentId}",
                method = "DELETE",
                permission = "users.assignment.delete.*",
                status = true
            },
            new
            {
                id = 19,
                endpoint = "/user/{id}/password",
                method = "PUT",
                permission = "users.password.self",
                status = true
            },
            new
            {
                id = 20,
                endpoint = "/user/{id}/password",
                method = "PUT",
                permission = "users.password.*",
                status = true
            },
            new
            {
                id = 21,
                endpoint = "/user/{id}/assignments",
                method = "GET",
                permission = "users.assignment.read.self",
                status = true
            },
            new
            {
                id = 22,
                endpoint = "/user/{id}/assignments",
                method = "GET",
                permission = "users.assignment.read.subordinate",
                status = true
            },
            new
            {
                id = 23,
                endpoint = "/user/{id}/assignments",
                method = "GET",
                permission = "users.assignment.read.*",
                status = true
            },
            new
            {
                id = 24,
                endpoint = "/auth/logout",
                method = "POST",
                permission = "auth.logout.self",
                status = true
            },
            new
            {
                id = 25,
                endpoint = "/auth/access",
                method = "GET",
                permission = "auth.access.self",
                status = true
            }
        );
        /* ========================= ROLES DE USUARIOS =========================================================*/
        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(r => r.id);
            entity.Property(r => r.name).IsRequired().HasMaxLength(50);
            entity.HasOne(r => r.nameRule)
                .WithMany(nm => nm.roles)
                .HasForeignKey(r => r.idNameRule);
        });
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
                name = "Empleado",
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6)),
                code = RoleCode.Empleado,
                idNameRule = 5
            }
        );

        /* ========================== ASIGNACION DE UNA REGLA Y LOS ACCESOS A LOS ENDPOINT PARA EL ACCESS TOKEN ======================================*/
        modelBuilder.Entity<EndpointAccessNameRule>(entity =>
        {
            entity.HasKey(r => r.id);
            entity.HasOne(r => r.endpointAccess)
                .WithMany(e => e.endpointAccessNameRules)
                .HasForeignKey(r => r.idEndpointAccess)
                .IsRequired();
            entity.HasOne(r => r.nameRule)
                .WithMany(nr => nr.endpointAccessNameRules)
                .HasForeignKey(r => r.idNameRule)
                .IsRequired();
        });

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

        /* ================================== ASIGNACION DE USUARIO A UN ROLE =============================================*/
        modelBuilder.Entity<UserAssignments>(entity =>
        {
            entity.HasKey(uax => uax.id);
            entity.Property(uax => uax.codeEmployee).HasMaxLength(15);
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
                codeEmployee = "EMP-02",
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
                codeEmployee = "EMP-03",
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
                codeEmployee = "EMP-04",
                idRole = 6,
                scopeType = scopeType.team,
                scopeId = (int?)1,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 13,
                idUser = 13,
                codeEmployee = "EMP-05",
                idRole = 6,
                scopeType = scopeType.team,
                scopeId = (int?)1,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 14,
                idUser = 14,
                codeEmployee = "EMP-06",
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
                codeEmployee = "EMP-07",
                idRole = 6,
                scopeType = scopeType.team,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 16,
                idUser = 16,
                codeEmployee = "EMP-08",
                idRole = 6,
                scopeType = scopeType.team,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 17,
                idUser = 17,
                codeEmployee = "EMP-09",
                idRole = 6,
                scopeType = scopeType.team,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            },
            new
            {
                id = 18,
                idUser = 18,
                codeEmployee = "EMP-10",
                idRole = 6,
                scopeType = scopeType.team,
                scopeId = (int?)2,
                isActive = true,
                created = new DateTimeOffset(2026, 2, 7, 0, 0, 0, TimeSpan.FromHours(-6))
            }
        );

        /*============================== ACCESO DE ROLES A PERFILES/TABLAS ======================*/
        modelBuilder.Entity<ProfileAccess>(entity =>
        {
            entity.HasKey(pa => pa.id);
            entity.Property(pa => pa.profileTable).IsRequired().HasMaxLength(60);
            entity.Property(pa => pa.canRead).IsRequired().HasDefaultValue(false);
            entity.Property(pa => pa.canWrite).IsRequired().HasDefaultValue(false);
            entity.HasIndex(pa => new { pa.idRole, pa.profileTable }).IsUnique();
            entity.HasOne(pa => pa.roles)
                .WithMany()
                .HasForeignKey(pa => pa.idRole)
                .IsRequired();
        });

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