using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace SystemBase.Repositorio;
using Data;
using Models;
using Models.snapshot;
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
    
    public Task<List<OldRefreshToken>> GetOldRefreshTokens(int userId)
    {
        return _db.refreshTokens
            .Where(r => r.idUser == userId && r.isActive)
            .AsNoTracking()
            .Select(r => new OldRefreshToken
            {
                id = r.id,
                createdAt = r.createdAt
            }).ToListAsync();
    }

    public async Task AddRefreshTokens(refreshTokens refreshTokens)
    {
        await _db.AddAsync(refreshTokens);
        await _db.SaveChangesAsync();
    }

    public Task DisabledRefreshTokens(int idRefreshToken)
    {
        _db.refreshTokens.Where(r => r.id == idRefreshToken && r.isActive)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(atr => atr.isActive, false));
        return Task.CompletedTask;
    }

    public Task<refreshTokens?> RefreshTokensExist(string refreshToken)
    {
        return _db.refreshTokens.FirstOrDefaultAsync(r =>
            r.tokenHash == refreshToken
        );
    }

    public Task<UserNewAccessToken?> UserClaimNeed(int userId)
    {
        return _db.users
            .AsNoTracking()
            .Where(u => u.id == userId)
            .Select(u => new UserNewAccessToken(
                u.id,
                u.userName,
                u.name
            )).FirstOrDefaultAsync();
    }

    public async Task<bool> TryDisabledRefreshTokens(int idRefreshToken)
    {
        var affectedRows = await _db.refreshTokens.Where(r =>
            r.id == idRefreshToken && r.isActive).ExecuteUpdateAsync(setters => 
            setters.SetProperty(atr => atr.isActive, false));
        return affectedRows >0;
    }

}
