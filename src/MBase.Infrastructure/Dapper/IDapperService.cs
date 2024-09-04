namespace MBase.Infrastructure.Dapper
{
    public interface IDapperService
    {
        Task<IEnumerable<T?>> Query<T>(string query);
        void SetConnectionString(string connectionString);
    }
}
