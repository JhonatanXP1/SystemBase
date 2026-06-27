using SystemBase.Services.IServices;

namespace SystemBase.Services;

// Implementación única; se registra como Scoped y se resuelve tanto por IRequestContext (lectura)
// como por IRequestContextInitializer (escritura) — ambas resuelven a la MISMA instancia por petición.
public class RequestContext : IRequestContext, IRequestContextInitializer
{

    public int? userId { get; private set; }
    public string? userName { get; private set; }
    public string? scopeName { get; private set; } 
    public int? scopeId {get; private set;}
    public IReadOnlyList<string> matchedPermissions { get; private set; } = [];
    public string clientIp { get; private set; } = "";
    public string userAgent { get; private set; } = "";
    public string requestId { get; private set; } = "";
    public bool hasUser => userId.HasValue;

    public void Initialize(
        int? userId,
        string? userName,
        string? activeScope,
        string clientIp,
        string userAgent,
        string requestId)
    {
        this.userId = userId;
        this.userName = userName;
        this.clientIp = clientIp;
        this.userAgent = userAgent;
        this.requestId = requestId;

        if (!String.IsNullOrEmpty(activeScope))
        {
            string[] partScope = activeScope.Split(":");
            if (partScope.Length == 2)
            {
                scopeName =  partScope[0] ;
                scopeId = int.Parse(partScope[1]);
            }
                
        }
    }

    public void SetMatchedPermissions(IReadOnlyList<string> matched)
    {
        matchedPermissions = matched;
    }
}
