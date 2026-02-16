using System.Security.Cryptography;
using System.Text;
using SystemBase.Services.IServices;

namespace SystemBase.Services;

using Isopoh.Cryptography.Argon2;

public class PasswordHasher : IPasswordHasher
{
    private const int MemoryCostKb = 32768; // 32 MB
    private const int TimeCost = 3;
    private const int Lanes = 2;
    private const int Threads = 2;
    private const int SaltBytes = 16;
    private const int HashBytes = 32;

    private byte[] GenerateSalt(int size)
    {
        byte[] salt = new byte[size];
        RandomNumberGenerator.Fill(salt);
        return salt;
    }

    public string Hash(string password)
    {
        var config = new Argon2Config
        {
            Type = Argon2Type.HybridAddressing, // Argon2id
            Version = Argon2Version.Nineteen, // v=19
            TimeCost = TimeCost,
            MemoryCost = MemoryCostKb,
            Lanes = Lanes,
            Threads = Threads,
            Password = Encoding.UTF8.GetBytes(password),
            Salt = GenerateSalt(16),
            HashLength = HashBytes
        };
        using var argon2 = new Argon2(config);
        var hash = argon2.Hash();
        return config.EncodeString(hash.Buffer);
    }

    public bool Verify(string storedHash, string password)
    {
        if (string.IsNullOrWhiteSpace(storedHash) || string.IsNullOrWhiteSpace(password))
            return false;

        return Argon2.Verify(storedHash, password);
    }
}