using Npgsql;

namespace MBase.Infrastructure.Dapper.Npgsql
{
    public class NpgSqlService(Connection<NpgsqlConnection> connection) : IDapperService
    {
        public async Task<IEnumerable<T?>> Query<T>(string query)
        {
            return await connection.QueryAsync<T>(query);
        }

        public void SetConnectionName(string connectionName)
        {
            connection.SetConnectionName(connectionName);
        }
    }
}
