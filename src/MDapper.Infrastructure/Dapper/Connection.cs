using System.Data.Common;
using System.Data;
using Dapper;

namespace MDapper.Infrastructure.Dapper
{
    public abstract class Connection<TDbConnection>(TDbConnection dbConnection) where TDbConnection : DbConnection
    {
        public string ConnectionString => dbConnection.ConnectionString;

        public IDbConnection GetConnection()
        {
            return dbConnection;
        }

        public Connection<TDbConnection> SetConnectionName(string connectionString)
        {
            dbConnection.ConnectionString = connectionString;

            return this;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query)
        {
            return await dbConnection.QueryAsync<T>(query);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object parameters)
        {
            return await dbConnection.QueryAsync<T>(query, parameters);
        }

        public async Task<int> ExecuteAsync(string query)
        {
            return await dbConnection.ExecuteAsync(query);
        }

        public async Task<int> ExecuteAsync(string query, object parameters)
        {
            return await dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task OpenAsync()
        {
            if (dbConnection.State == ConnectionState.Closed)
                await dbConnection.OpenAsync();
        }

        public async Task CloseAsync()
        {
            if (dbConnection.State == ConnectionState.Open)
                await dbConnection.CloseAsync();
        }
    }
}