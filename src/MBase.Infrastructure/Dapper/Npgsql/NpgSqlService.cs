using Npgsql;

namespace MBase.Infrastructure.Dapper.Npgsql
{
    public class NpgSqlService(IConnection<NpgsqlConnection> connection) : IDapperService
    {
        public async Task<IEnumerable<T?>> Query<T>(string query)
        {
            return await connection.QueryAsync<T>(query);
        }

        public void SetConnectionString(string connectionName)
        {
            connection.SetConnectionString(connectionName);
        }
    }
}
