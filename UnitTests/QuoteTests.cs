using System;
using System.Linq;
using IQuotes.Data;
using IQuotes.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    namespace UnitTests
    {
        public class QuoteTests
        {
            [Fact]
            public void AddQuoteToDatabase_ShouldSucceed()
            {
                // arrange
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    // create the database schema
                    context.Database.EnsureCreated();

                    var quote = new Quotes
                    {
                        Username = "TestUser",
                        QuoteText = "This is a test quote.",
                        CreatedAt = DateTime.UtcNow
                    };

                    // act
                    context.Quotes.Add(quote);
                    context.SaveChanges();

                    // assert
                    var savedQuote = context.Quotes.FirstOrDefault(q => q.Username == "TestUser" && q.QuoteText == "This is a test quote.");
                    Assert.NotNull(savedQuote);

                 
                    var expectedResult = quote;

      
                    var actualResult = savedQuote;

                    // assert
                    Assert.Equal(expectedResult.Username, actualResult.Username);
                    Assert.Equal(expectedResult.QuoteText, actualResult.QuoteText);
                    Assert.Equal(expectedResult.CreatedAt, actualResult.CreatedAt, TimeSpan.FromSeconds(1)); 
                }
            }
        }
    }

}
