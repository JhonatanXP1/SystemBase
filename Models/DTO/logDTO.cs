namespace SystemBase.Models.DTO;
using System.ComponentModel.DataAnnotations;

public class logingDTO
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string? userName { get; set; }
    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string? password { get; set; }
}

public class sessionStartedDTO
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public UserSessionDTO User { get; set; }
}
    
public class UserSessionDTO
{
    public int id { get; set; }
    public string userName { get; set; }
    public string name { get; set; }
    public string? app { get; set; }
    public string? apm { get; set; }
    public bool status { get; set; }
}