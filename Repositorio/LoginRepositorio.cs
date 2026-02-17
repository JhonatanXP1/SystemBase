using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace SystemBase.Repositorio;
using Data;
using Models;
using Mappers.IMappers;
using IRepositorio;

public class LoginRepositorio : ILoginRepositorio
{
    private readonly AplicationDbContext _db;
    private readonly ILoginMapper _mapper;

    public LoginRepositorio(AplicationDbContext db, ILoginMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public Task<users?>
        LoginUser(string userName) // Busca el usuario en la base de datos por su nombre de usuario y contraseña
    {
        return _db.users.FirstOrDefaultAsync(u =>
            u.userName == userName &&
            u.status);
    }

    public async Task<List<refreshTokens>> ListRefreshTokensExist(int userId)
    {
        return await _db.refreshTokens
            .Where(r => r.idUser == userId && r.isActive)
            .ToListAsync();
    }

    public Task<int> CountRefreshTokensExistAsyncron(int userId)
    {
        return _db.refreshTokens.CountAsync(r =>
            r.idUser == userId &&
            r.isActive);
    }

    public async Task AddRefreshTokens(refreshTokens refreshTokens)
    {
        await _db.AddAsync(refreshTokens);
        await _db.SaveChangesAsync();
    }
}
