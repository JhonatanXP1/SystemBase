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
    
    public users? LoginUser(string userName, string password) // Busca el usuario en la base de datos por su nombre de usuario y contraseña
    {
        var user = _db.users.FirstOrDefault(u => u.userName == userName && u.password == password);
        return user;
    }

    public List<refreshTokens> ListRefreshTokensExist(int userId)
    {
        List<refreshTokens> listRefreshActivos = _db.refreshTokens
            .Where(r => 
                r.idUser == userId &&
                r.isActive).ToList();
        return listRefreshActivos;
    }

    public int CountRefreshTokensExist(int userId)
    {
        return _db.refreshTokens
    }
    
    
}
