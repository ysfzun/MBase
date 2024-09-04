using System.Data;
using System.Data.Common;
using Dapper;

namespace MBase.Infrastructure.Dapper
{
    public interface IConnection<TDbConnection> where TDbConnection : DbConnection
    {
        IDbConnection GetConnection();
        Connection<TDbConnection> SetConnectionString(string connectionString);
        Task<IEnumerable<T>> QueryAsync<T>(string query);
        Task<IEnumerable<T>> QueryAsync<T>(string query, object parameters);
        Task<int> ExecuteAsync(string query);
        Task<int> ExecuteAsync(string query, object parameters);
        Task OpenAsync();
        Task CloseAsync();
    }

    public class Connection<TDbConnection>(TDbConnection dbConnection) : IConnection<TDbConnection> where TDbConnection : DbConnection
    {
        public string ConnectionString => dbConnection.ConnectionString;

        public IDbConnection GetConnection()
        {
            return dbConnection;
        }

        public Connection<TDbConnection> SetConnectionString(string connectionString)
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