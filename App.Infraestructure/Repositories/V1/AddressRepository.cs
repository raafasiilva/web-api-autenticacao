using App.Domain.Interfaces.Repositories.V1;
using App.Domain.Models.Entities.Schemas.Authentication;
using App.Infraestructure.DbContexts;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace App.Infraestructure.Repositories.V1
{
    public class AddressRepository(DbContextOptions<AuthenticationDbContext> dbContextOptions, DapperDbContext dapperDbContext) 
        : TEntityRepository<Address, AuthenticationDbContext>(dbContextOptions), IAddressRepository
    {
        private readonly DapperDbContext _dapperDbContext = dapperDbContext;

        public async Task<bool> HasByIdAsync(Guid id)
        {
            using IDbConnection dbConnection = _dapperDbContext.DbConnection;
            string query = "SELECT Id FROM autenticacao.endereco WHERE Id = @id";
            return (await dbConnection.QueryAsync(query, new { id })).Any();
        }
    }
}