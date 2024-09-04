using MBase.Infrastructure.Dapper;
using MBase.Infrastructure.Dapper.Npgsql;
using Moq;
using Npgsql;
using Xunit;

namespace MBase.Infrastructure.Tests.Dapper.Npgsql
{
    public class NpgSqlServiceTests
    {
        private readonly Mock<IConnection<NpgsqlConnection>> _mockConnection;
        private readonly NpgSqlService _npgSqlService;

        public NpgSqlServiceTests()
        {
            _mockConnection = new Mock<IConnection<NpgsqlConnection>>();
            _npgSqlService = new NpgSqlService(_mockConnection.Object);
        }

        [Fact]
        public async Task Query_ShouldCallQueryAsyncAndReturnResult()
        {
            var query = "SELECT * FROM Maps";

            var expected = new List<Map> { new() { Id = 1, Name = "Europe" } };
            _mockConnection.Setup(p => p.QueryAsync<Map>(query))
                .ReturnsAsync(expected);

            var result = await _npgSqlService.Query<Map>(query);

            _mockConnection.Verify(c => c.QueryAsync<Map>(query), Times.Once);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SetConnectionString_ShouldCallSetConnectionString()
        {
            var connectionString = "Server=localhost;Database=TestDb;";

            _npgSqlService.SetConnectionString(connectionString);
            _mockConnection.Verify(c => c.SetConnectionString(connectionString), Times.Once);
        }
    }
}