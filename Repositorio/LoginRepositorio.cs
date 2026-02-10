namespace SystemBase.Repositorio;
using SystemBase.Data;
public class LoginRepositorio
{
    private readonly AplicationDbContext Db;

    public LoginRepositorio(AplicationDbContext db)
    {
        Db = db;
    }
}
