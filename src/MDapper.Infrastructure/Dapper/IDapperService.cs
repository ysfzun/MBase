namespace MBase.Infrastructure.Dapper
{
    public interface IDapperService
    {
        Task<IEnumerable<T?>> Query<T>(string query);
        void SetConnectionName(string connectionName);
    }
}
