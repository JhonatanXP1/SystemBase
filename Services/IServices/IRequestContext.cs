namespace SystemBase.Services.IServices;

// Contexto de la petición HTTP actual: usuario, scope activo, permisos matched, info del cliente.
// READ-ONLY para servicios y controllers. La pipeline (middleware + auth handler) rellena vía IRequestContextInitializer.
public interface IRequestContext
{
    int? UserId { get; }
    string? UserName { get; }
    string? ActiveScope { get; }
    IReadOnlyList<string> MatchedPermissions { get; }
    string ClientIp { get; }
    string UserAgent { get; }
    string RequestId { get; }
    bool HasUser { get; }
}
