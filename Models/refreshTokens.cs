namespace SystemBase.Models;

public class refreshTokens
{
    public int id { get; set; }
    public int idUser { get; set; }
    public string tokenHash { get; set; }

    public DateTimeOffset expiresAt { get; set; }
    public DateTimeOffset createdAt { get; set; }

    public string? ipAddress { get; set; }
    public string? agentUserName { get; set; }
    public bool isActive { get; set; }
    
    public users? User { get; set; }
}