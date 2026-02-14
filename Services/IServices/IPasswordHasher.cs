namespace SystemBase.Services.IServices;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string storedHash, string password);
}