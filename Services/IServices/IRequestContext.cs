namespace SystemBase.Services.IServices;

// Contexto de la petición HTTP actual: usuario, scope activo, permisos matched, info del cliente.
// READ-ONLY para servicios y controllers. La pipeline (middleware + auth handler) rellena vía IRequestContextInitializer.
public interface IRequestContext
{
    int? userId { get; }
    string? userName { get; }
    string? scopeName { get; }
    int? scopeId { get; }
    IReadOnlyList<string> matchedPermissions { get; }
    string clientIp { get; }
    string userAgent { get; }
    string requestId { get; }
    bool hasUser { get; }
}
