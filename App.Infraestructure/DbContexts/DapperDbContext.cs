using Npgsql;
using System.Data;

namespace App.Infraestructure.DbContexts
{
    public class DapperDbContext
    {
        private readonly string _connectionString;

        public DapperDbContext(string connectionString) => _connectionString = connectionString;

        public virtual IDbConnection DbConnection => new NpgsqlConnection(_connectionString);
    }
}
