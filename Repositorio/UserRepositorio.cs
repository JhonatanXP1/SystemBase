using Microsoft.EntityFrameworkCore;
using SystemBase.Data;
using SystemBase.Repositorio.IRepositorio;

namespace SystemBase.Repositorio;

public class UserRepositorio(AplicationDbContext db):IUserRepositorio
{
    private readonly AplicationDbContext _db = db;
    public Task<string?> GetPasswordByIdAsync(int id)
    {
        return await null;
    }
}