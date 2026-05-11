using SystemBase.Models.DTO;

namespace SystemBase.Models.Snapshot;

public class SessionStarted : IAccessService
{
    public string Token { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public string RefreshToken { get; set; }
    public DateTimeOffset refreshExpiresAt { get; set; }
}

public class OldRefreshToken
{
    public int id { get; set; }
    public DateTimeOffset createdAt { get; set; }
}

public sealed record UserNewAccessToken(
    int id,
    string userName,
    string? name,
    string? app,
    string? apm,
    bool status
) : IUserTokenInfo;

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
    string? app { get; }
    string? apm { get; }
    bool status { get; }
}


public class refreshToken : IAccessService
{
    public string Token { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public string RefreshToken { get; set; }
    public DateTimeOffset refreshExpiresAt { get; set; }
}

public interface IAccessService
{
    public string Token { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public string RefreshToken { get; set; }
    public DateTimeOffset refreshExpiresAt { get; set; }
}