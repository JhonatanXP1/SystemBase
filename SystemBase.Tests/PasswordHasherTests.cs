using SystemBase.Services;
namespace SystemBase.Tests;
public class PasswordHasherTests
{
    private readonly PasswordHasher _hasher = new();
    
    [Fact]
    public void Hash_NoDebeDevolverPasswordPlano()
    {
        // Arrange
        const string password = "MiClaveSegura123!";

        // Act
        string hash = _hasher.Hash(password);
        // Assert
        Assert.NotEqual(password, hash);
        Assert.False(string.IsNullOrWhiteSpace(hash));
        Assert.StartsWith("$argon2", hash);
        
    }
}