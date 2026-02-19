namespace SystemBase.Services.IServices;

public interface IHttpContextService
{
    string GetClientIpAddress();
    string GetUserAgent();
}