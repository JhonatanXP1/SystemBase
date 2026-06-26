namespace SystemBase.Services.IServices;

// Interfaz de ESCRITURA del contexto. Solo la pipeline HTTP la usa
// (RequestContextMiddleware al inicio + PermissionAuthorizationHandler para MatchedPermissions).
// Los servicios de negocio NO deben inyectar esta interfaz.
public interface IRequestContextInitializer
{
    void Initialize(
        int? userId,
        string? userName,
        string? activeScope,
        string clientIp,
        string userAgent,
        string requestId);

    void SetMatchedPermissions(IReadOnlyList<string> matched);
}
