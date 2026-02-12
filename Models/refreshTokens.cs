namespace SystemBase.Models;

public class refreshTokens
{
    public int id { get; set; }
    public int idUser  { get; set; }
    public string token { get; set; }
    public DateTime expiresAt { get; set; }
    
}