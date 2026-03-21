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

    [Fact]
    public void Hash_ValidarPasswordHasheado()
    {
        //Arrange
        const string password = "Jhonatan11+";
        //Act
        string hash = _hasher.Hash(password);
        //Assert
        Assert.NotEqual(password, hash);
        Assert.True(_hasher.Verify(hash, "Jhonatan11+"));
        Assert.False(_hasher.Verify(hash, "jhonatan11+"));
    }

    [Fact]
    public void Hash_ValidarPasswordHasher_To_Empty()
    {
        //Arrange
        const string password = "Jhonatan11";
        //Act
        string hash = _hasher.Hash(password);
        //Assert
        Assert.NotEqual(password, hash);
        Assert.False(_hasher.Verify(hash, ""));
        Assert.False(_hasher.Verify("", password));
    }
    
}