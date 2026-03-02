using Azure.Core;
using Microsoft.Data.SqlClient;
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

    public Task DisabledRefreshToken(int idRefreshToken)
    {
        return _db.refreshTokens.Where(r => r.id == idRefreshToken && r.isActive)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(atr => atr.isActive, false));
    }

    public Task DisabledRefreshTokensAll(int idUser = 0, string refreshToken = "")  
    {
        var sql = @"IF @idUser > 0
    BEGIN
        UPDATE refreshTokens
        SET isActive = 0
        WHERE idUser = @idUser
          AND isActive = 1
    END
    IF NULLIF(@refreshToken, '') IS NOT NULL
    BEGIN
        UPDATE refreshTokens
        SET isActive = 0
        WHERE idUser IN (
            SELECT idUser
            FROM refreshTokens
            WHERE tokenHash = @refreshToken AND isActive = 1
        )
    END";

        return _db.Database.ExecuteSqlRawAsync(sql,
            new SqlParameter("@idUser", idUser),
            new SqlParameter("@refreshToken", refreshToken));
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
        return affectedRows > 0;
    }
}