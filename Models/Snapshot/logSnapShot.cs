namespace SystemBase.Models.snapshot;
using SystemBase.Models.DTO;

public class SessionStarted:IAccessService
{
    public string Token { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public string RefreshToken { get; set; }
    public DateTimeOffset refreshExpiresAt  { get; set; }
    public UserSessionDTO User { get; set; }
}
public sealed record UserNewAccessToken(
    int id,
    string userName,
    string? name
):IUserTokenInfo;

public class refreshTokenProccess
{
    public int id { get; set; }
    public string tokenHash { get; set; }
    public DateTimeOffset expiresAt { get; set; }
    public DateTimeOffset SessionExpiresAt { get; set; }
}

public interface IUserTokenInfo
{
    int id { get; }
    string userName { get; }
    string? name { get; }
}

public class refreshToken():IAccessService
{
    public string Token { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public string RefreshToken { get; set; }
    public DateTimeOffset refreshExpiresAt  { get; set; }
}

public interface IAccessService
{
    public string Token { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public string RefreshToken { get; set; }
    public DateTimeOffset refreshExpiresAt  { get; set; }
}