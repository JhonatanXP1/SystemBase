namespace SystemBase.Models.ReadModels;

// Read model plano de la capa de datos: solo las columnas que necesita el dashboard.
// roleCode se devuelve crudo (int?); el formateo a string es presentación y vive en el servicio.
public sealed record UserDashboardRow(
    int id,
    string? imageUser,
    string name,
    string? app,
    string? apm,
    string userName,
    bool status,
    int? roleCode,
    string? roleName);