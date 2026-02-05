using Microsoft.EntityFrameworkCore;
using SystemBase.Models;

namespace SystemBase.Data;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<users> users { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<users>(users =>
        {
            //definimos primarykey
            users.HasKey(u => u.id);
            users.Property(u => u.userName).IsRequired().HasMaxLength(15);
            users.Property(u=>u.password).IsRequired().HasMaxLength(16);
            users.Property(u => u.name).IsRequired().HasMaxLength(50);
            users.Property(u=>u.app).HasMaxLength(50);
            users.Property(u=>u.apm).HasMaxLength(50);
            users.Property(u =>u.created).IsRequired();
            users.Property(u=>u.status).HasDefaultValue(true);
        });
    }
}       