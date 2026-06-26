using Microsoft.EntityFrameworkCore;
using SystemBase.Data.Seeders;
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

    // Jerarquía organizacional (scope) — catálogos + cadena de puentes.
    public DbSet<Company> companies { get; set; }
    public DbSet<Campus> campuses { get; set; }
    public DbSet<Area> areas { get; set; }
    public DbSet<WorkShift> workShifts { get; set; }
    public DbSet<Team> teams { get; set; }
    public DbSet<CampusArea> campusAreas { get; set; }
    public DbSet<CampusAreaWorkShift> campusAreaWorkShifts { get; set; }
    public DbSet<CampusAreaWorkShiftTeam> campusAreaWorkShiftTeams { get; set; }

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

        /* ========================== NOMBRE A LA REGLAS DE ACCESO AL USUARIO ======================================*/
        modelBuilder.Entity<NameRule>(entity =>
        {
            entity.HasKey(r => r.id);
            entity.Property(r => r.name).IsRequired().HasMaxLength(50);
        });

        /* ========================== REGLAS DEFINIDAS PARA EL ACCESS TOKEN ======================================*/
        modelBuilder.Entity<endpointAccess>(entity => { entity.HasKey(r => r.id); });
        /* ========================= ROLES DE USUARIOS =========================================================*/
        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(r => r.id);
            entity.Property(r => r.name).IsRequired().HasMaxLength(50);
            entity.HasOne(r => r.nameRule)
                .WithMany(nm => nm.roles)
                .HasForeignKey(r => r.idNameRule);
        });

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

        /*============================== JERARQUÍA ORGANIZACIONAL (SCOPE) =========================================*/
        // Catálogos
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(c => c.id);
            entity.Property(c => c.name).IsRequired().HasMaxLength(150);
            entity.Property(c => c.direccion).HasMaxLength(255);
            entity.Property(c => c.created).IsRequired();
        });
        modelBuilder.Entity<Campus>(entity =>
        {
            entity.HasKey(c => c.id);
            entity.Property(c => c.code).IsRequired(); // CampusCode (enum) almacenado como número
            entity.Property(c => c.name).IsRequired().HasMaxLength(150);
            entity.Property(c => c.direccion).HasMaxLength(255);
            entity.Property(c => c.created).IsRequired();
            entity.HasOne(c => c.company).WithMany()
                .HasForeignKey(c => c.idCompany).IsRequired().OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(a => a.id);
            entity.Property(a => a.name).IsRequired().HasMaxLength(150);
            entity.Property(a => a.code).HasMaxLength(50);
            entity.Property(a => a.created).IsRequired();
        });
        modelBuilder.Entity<WorkShift>(entity =>
        {
            entity.HasKey(w => w.id);
            entity.Property(w => w.name).IsRequired().HasMaxLength(150);
            entity.Property(w => w.hourInit).IsRequired();
            entity.Property(w => w.hourEnd).IsRequired();
            entity.Property(w => w.created).IsRequired();
        });
        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(t => t.id);
            entity.Property(t => t.name).IsRequired().HasMaxLength(150);
            entity.Property(t => t.created).IsRequired();
        });

        // Cadena de puentes (Restrict para evitar múltiples rutas de cascada en SQL Server)
        modelBuilder.Entity<CampusArea>(entity =>
        {
            entity.HasKey(ca => ca.id);
            entity.Property(ca => ca.created).IsRequired();
            entity.HasIndex(ca => new { ca.idCampus, ca.idArea }).IsUnique();
            entity.HasOne(ca => ca.campus).WithMany()
                .HasForeignKey(ca => ca.idCampus).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(ca => ca.area).WithMany()
                .HasForeignKey(ca => ca.idArea).IsRequired().OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<CampusAreaWorkShift>(entity =>
        {
            entity.HasKey(x => x.id);
            entity.Property(x => x.created).IsRequired();
            entity.HasIndex(x => new { x.idCampusArea, x.idWorkShift }).IsUnique();
            entity.HasOne(x => x.campusArea).WithMany()
                .HasForeignKey(x => x.idCampusArea).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.workShift).WithMany()
                .HasForeignKey(x => x.idWorkShift).IsRequired().OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<CampusAreaWorkShiftTeam>(entity =>
        {
            entity.HasKey(x => x.id);
            entity.Property(x => x.created).IsRequired();
            entity.HasIndex(x => new { x.idCampusAreaWorkShift, x.idTeam }).IsUnique();
            entity.HasOne(x => x.campusAreaWorkShift).WithMany()
                .HasForeignKey(x => x.idCampusAreaWorkShift).IsRequired().OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.team).WithMany()
                .HasForeignKey(x => x.idTeam).IsRequired().OnDelete(DeleteBehavior.Restrict);
        });

        /*============================== DATOS SEMBRADOS (Data/Seeders/) =========================================*/
        modelBuilder.ApplySeeders(_passwordHasher);
    }
}