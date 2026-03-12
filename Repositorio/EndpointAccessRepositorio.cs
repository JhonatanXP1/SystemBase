using SystemBase.Data;
using Microsoft.Data.SqlClient;
using SystemBase.Repositorio.IRepositorio;

namespace SystemBase.Repositorio;

public class EndpointAccessRepositorio (AplicationDbContext db):IEndpointAccessRepositorio
{
    private readonly AplicationDbContext _db = db;

    public async Task<List<string>?> GetEndpoints(string codeEmploy, int idUserAssigments)
    {
        
        return null;
    }
}