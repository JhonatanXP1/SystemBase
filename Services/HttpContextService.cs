using SystemBase.Services.IServices;

namespace SystemBase.Services;

public class HttpContextService:IHttpContextService
{
    private readonly IHttpContextAccessor _accessor;
    
    public HttpContextService(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    
    public string GetClientIpAddress()
    {
        var context = _accessor.HttpContext;
        string? ip= context != null && context.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedFor) // Recuerda!!! configurar Nginx
            ? forwardedFor.FirstOrDefault()?.Split(',').FirstOrDefault()?.Trim()
            : context?.Connection.RemoteIpAddress?.ToString();
        return ip ?? "";
    }

    public string GetUserAgent()
    {
        return _accessor.HttpContext?.Request.Headers["User-Agent"].ToString() ?? "";
    }
}