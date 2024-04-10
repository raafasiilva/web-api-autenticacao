using Npgsql;
using System.Data;

namespace App.Infraestructure.DbContexts
{
    public class DapperDbContext(string connectionString)
    {
        private readonly string _connectionString = connectionString;

        public virtual IDbConnection DbConnection => new NpgsqlConnection(_connectionString);
    }
}
