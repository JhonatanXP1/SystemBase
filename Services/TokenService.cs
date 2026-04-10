using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using SystemBase.Models.Snapshot;
using SystemBase.Services.IServices;

namespace SystemBase.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IHostEnvironment _hostEnvironment;

    public TokenService(IConfiguration configuration, IHostEnvironment environment)
    {
        _configuration = configuration;
        _hostEnvironment = environment;
    }


    public (string token, DateTimeOffset expiresAt) CreateAccessToken(IUserTokenInfo user,
        List<PermisosXAsignacion> permisions)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var minutes = int.Parse(_configuration["Jwt:AccessTokenMinutes"]!);

        var privatePem = GetPrivatePem();

        using (var rsa = RSA.Create())
        {
            rsa.ImportFromPem(privatePem);
            var rsaKey = new RsaSecurityKey(rsa.ExportParameters(true))
            {
                KeyId = "main-rsa" // opcional, pero recomendado
            };
            var creds = new SigningCredentials(rsaKey, SecurityAlgorithms.RsaSha256);
            var expiresAt = DateTimeOffset.UtcNow.AddMinutes(minutes);
            var permisos = PermissionsEndPoints(permisions);

            var jwt = new JwtSecurityToken(
                issuer,
                audience,
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.userName),
                    new Claim("preferred_username", user.userName),
                    new Claim(JwtRegisteredClaimNames.Name, user.name ?? ""),
                    new Claim("perm", JsonSerializer.Serialize(permisos), JsonClaimValueTypes.Json)
                },
                expires: expiresAt.UtcDateTime,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(jwt), expiresAt);
        }
    }

    private Dictionary<string, List<string>> PermissionsEndPoints(List<PermisosXAsignacion> noProcessPermissions)
    {
        var permisos = new Dictionary<string, List<string>>();
        foreach (var item in noProcessPermissions)
        {
            var key = item.scopeTypeToidUserAssignaments;

            if (!permisos.TryGetValue(key, out var lista))
            {
                lista = new List<string>();
                permisos[key] = lista;
            }

            lista.Add(item.permission);
        }

        return permisos;
    }

    public string CreateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }

    // Convierto el token del Json y lo encripto para guardarlo en base de datos.
    public string HashRefreshToken(string refreshToken)
    {
        var claveSecret = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:secretWord")!);
        var refreshTokenSecret = Encoding.UTF8.GetBytes(refreshToken);
        using (var hmac = new HMACSHA256(claveSecret))
        {
            return Convert.ToBase64String(hmac.ComputeHash(refreshTokenSecret));
        }
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

        var path = _configuration["Jwt:PublicKeyPath"]!;
        var full = Path.IsPathRooted(path) ? path : Path.Combine(_hostEnvironment.ContentRootPath, path);
        return File.ReadAllText(full);
    }
}