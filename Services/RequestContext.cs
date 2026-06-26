using SystemBase.Services.IServices;

namespace SystemBase.Services;

// Implementación única; se registra como Scoped y se resuelve tanto por IRequestContext (lectura)
// como por IRequestContextInitializer (escritura) — ambas resuelven a la MISMA instancia por petición.
public class RequestContext : IRequestContext, IRequestContextInitializer
{
    public int? UserId { get; private set; }
    public string? UserName { get; private set; }
    public string? ActiveScope { get; private set; }
    public IReadOnlyList<string> MatchedPermissions { get; private set; } = [];
    public string ClientIp { get; private set; } = "";
    public string UserAgent { get; private set; } = "";
    public string RequestId { get; private set; } = "";
    public bool HasUser => UserId.HasValue;

    public void Initialize(
        int? userId,
        string? userName,
        string? activeScope,
        string clientIp,
        string userAgent,
        string requestId)
    {
        UserId = userId;
        UserName = userName;
        ActiveScope = activeScope;
        ClientIp = clientIp;
        UserAgent = userAgent;
        RequestId = requestId;
    }

    public void SetMatchedPermissions(IReadOnlyList<string> matched)
    {
        MatchedPermissions = matched;
    }
}
