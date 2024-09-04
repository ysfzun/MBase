using System.Data.Common;
using Dapper;
using MBase.Infrastructure.Dapper;
using Moq;
using Moq.Dapper;
using Xunit;

namespace MBase.Infrastructure.Tests.Dapper.DapperConnection
{
    public class ConnectionTests
    {
        private readonly Mock<DbConnection> _mockDbConnection;
        private readonly Mock<Connection<DbConnection>> _connection;

        public ConnectionTests()
        {
            _mockDbConnection = new Mock<DbConnection>();
            _connection = new Mock<Connection<DbConnection>>(_mockDbConnection.Object);
        }

        [Fact]
        public void ConnectionString_ReturnsCorrectValue()
        {
            _mockDbConnection.SetupGet(x => x.ConnectionString).Returns("TestConnectionString");
            Assert.Equal("TestConnectionString", _connection.Object.ConnectionString);
        }

        [Fact]
        public async Task QueryAsync_ShouldReturnExpectedRecords()
        {
            var expected = new[] { 1, 2, 3 };

            _mockDbConnection.SetupDapperAsync(c => c.QueryAsync<int>("query", null, null, null, null))
                .ReturnsAsync(expected);

            var actual = (await _connection.Object.QueryAsync<int>("query")).ToList();

            Assert.Equal(actual.Count, expected.Length);
        }
    }
}
