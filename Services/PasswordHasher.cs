using SystemBase.Services.IServices;
using SystemBase.Services.IServices;

public class PasswordHasher: IPasswordHasher
{
    public string Hash(string password)
    {
        return "";
    }
    public bool Verify(string storedHash, string password)
    {
        return false;
    }
    
    
}