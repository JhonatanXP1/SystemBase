using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using SystemBase.Models.DTO;

namespace SystemBase.Services;
using IServices;
using Models.snapshot;
public class TokenService :ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IHostEnvironment _hostEnvironment;
    
    public TokenService(IConfiguration configuration, IHostEnvironment environment)
    {
        _configuration = configuration;
        _hostEnvironment = environment;
    }
    
    private string GetPrivatePem()
    {
        var fromEnv = Environment.GetEnvironmentVariable("JWT_PRIVATE_KEY_PEM");
        if (!string.IsNullOrWhiteSpace(fromEnv)) return fromEnv;
        
        var path = _configuration["Jwt:PrivateKeyPath"]!;
        var full = Path.IsPathRooted(path) ? path : Path.Combine(_hostEnvironment.ContentRootPath, path); 
        return File.ReadAllText(full);
    }

    private string GetPublicKey()
    {
        var fromEnv = Environment.GetEnvironmentVariable("JWT_PUBLIC_KEY_PEM");
        if (!string.IsNullOrWhiteSpace(fromEnv)) return fromEnv;
        
        var  path = _configuration["Jwt:PublicKeyPath"]!;
        var full = Path.IsPathRooted(path) ? path : Path.Combine(_hostEnvironment.ContentRootPath, path);
        return File.ReadAllText(full);
    }
    

    public (string token, DateTimeOffset expiresAt) CreateAccessToken(IUserTokenInfo user)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var minutes = int.Parse(_configuration["Jwt:AccessTokenMinutes"]!);
        
        var privatePem = GetPrivatePem();

        using (RSA rsa = RSA.Create())
        {
            rsa.ImportFromPem(privatePem);
            var rsaKey = new RsaSecurityKey(rsa.ExportParameters(true))
            {
                KeyId = "main-rsa" // opcional, pero recomendado
            };
            var creds = new SigningCredentials(rsaKey, SecurityAlgorithms.RsaSha256);
            var expiresAt = DateTimeOffset.UtcNow.AddMinutes(minutes);

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.userName),
                    new Claim("preferred_username", user.userName),
                    new Claim(JwtRegisteredClaimNames.Name, user.name)
                },
                expires: expiresAt.UtcDateTime,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(jwt), expiresAt);
        }
    }
    
    public string CreateRefreshToken()
        => Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

    // Convierto el token del Json y lo encripto para guardarlo en base de datos.
    public string HashRefreshToken(string refreshToken)
    {
        byte[] claveSecret = System.Text.Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:secretWord")!);
        byte[] refreshTokenSecret = System.Text.Encoding.UTF8.GetBytes(refreshToken);
        using (HMACSHA256 hmac = new HMACSHA256(claveSecret))
        {
           return Convert.ToBase64String(hmac.ComputeHash(refreshTokenSecret));
        }
    }
}