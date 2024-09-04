using MBase.Infrastructure.Dapper;
using MBase.Infrastructure.Dapper.Npgsql;
using Microsoft.EntityFrameworkCore;
using Moq;
using Npgsql;
using Xunit;

namespace MBase.Infrastructure.Tests.Dapper.Npgsql
{
    public class NpgSqlServiceTests
    {
        [Fact]
        public void SetConnection_ShouldSetNewConnectionString()
        {
            //const string expectedConnectionString = "connectionString";
            //var connection = new Mock<Connection<NpgsqlConnection>>();
            //var service = new NpgSqlService(connection.Object);
            //service.SetConnectionString(expectedConnectionString);

            //connection.Verify(p => p.SetConnectionString(expectedConnectionString), Times.Once);

            var mockConnection = new Mock<Connection<NpgsqlConnection>>();
            var service = new NpgSqlService(mockConnection.Object);
            var expectedConnectionName = "TestConnection";

            // Act
            service.SetConnectionString(expectedConnectionName);

            // Assert
            mockConnection.Verify(c => c.SetConnectionString(expectedConnectionName), Times.Once());
        }
    }
}