using System.Data;
using System.Data.Common;

namespace MBase.Infrastructure.Dapper;

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