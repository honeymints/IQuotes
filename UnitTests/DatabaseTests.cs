using Microsoft.EntityFrameworkCore;
using IQuotes.Data;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace UnitTests;

public class DatabaseTests
{
    public class DatabaseConnectionCheckerTests
    {
        [Fact]
        public void IsDatabaseConnected_ReturnsTrueWhenConnectionIsOpen()
        {
            // arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                // act
                var isConnected = context.Database.CanConnect();

                // assert
                Assert.True(isConnected);
            }
        }
    }
}
