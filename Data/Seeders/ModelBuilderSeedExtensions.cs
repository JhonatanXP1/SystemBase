using Microsoft.EntityFrameworkCore;
using SystemBase.Services.IServices;

namespace SystemBase.Data.Seeders;

// Punto único de entrada para todos los datos sembrados.
// El orden es informativo: EF resuelve el orden real de inserción por las FK; HasData no depende del orden de llamada.
public static class ModelBuilderSeedExtensions
{
    public static void ApplySeeders(this ModelBuilder modelBuilder, IPasswordHasher passwordHasher)
    {
        NameRuleSeeder.Seed(modelBuilder);
        EndpointAccessSeeder.Seed(modelBuilder);
        RolesSeeder.Seed(modelBuilder);
        EndpointAccessNameRuleSeeder.Seed(modelBuilder);

        // Jerarquía organizacional: catálogos + cadena de puentes (Campus*).
        CompanySeeder.Seed(modelBuilder);
        CampusSeeder.Seed(modelBuilder);
        AreaSeeder.Seed(modelBuilder);
        WorkShiftSeeder.Seed(modelBuilder);
        TeamSeeder.Seed(modelBuilder);
        CampusAreaSeeder.Seed(modelBuilder);
        CampusAreaWorkShiftSeeder.Seed(modelBuilder);
        CampusAreaWorkShiftTeamSeeder.Seed(modelBuilder);

        UsersSeeder.Seed(modelBuilder, passwordHasher);
        UserAssignmentsSeeder.Seed(modelBuilder);
    }
}