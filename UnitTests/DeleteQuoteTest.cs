using IQuotes.Data;
using Microsoft.EntityFrameworkCore;
using IQuotes.Models;
using Xunit;

namespace UnitTests;

public class DeleteQuoteTest
{
    [Fact]
    public void AddAndDeleteQuoteToDatabase_ShouldSucceed()
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
                    User = new User(),
                    QuoteText = "This is a test quote.",
                    CreatedAt = DateTime.UtcNow,
                    
                };

                quote.User.Username = "TestUser";
                quote.User.Password = "newpassword";
                quote.User.Email = "newemail123";
                // act: add the quote to the database
                context.Quotes.Add(quote);
                context.SaveChanges();

                // assert
                var savedQuote = context.Quotes.FirstOrDefault(q => q.User.Username == "TestUser" && q.QuoteText == "This is a test quote.");
                Assert.NotNull(savedQuote);
                
                var expectedResult = quote;

                
                var actualResult = savedQuote;

                // assert
                Assert.Equal(expectedResult.User.Username, actualResult.User.Username);
                Assert.Equal(expectedResult.QuoteText, actualResult.QuoteText);
                Assert.Equal(expectedResult.CreatedAt, actualResult.CreatedAt, TimeSpan.FromSeconds(1)); 

                // act: Delete the quote from the database
                context.Quotes.Remove(savedQuote);
                context.SaveChanges();
            }

            // assert: verify that the quote has been deleted
            using (var context = new ApplicationDbContext(options))
            {
                var deletedQuote = context.Quotes.FirstOrDefault(q => q.User.Username == "TestUser" && q.QuoteText == "This is a test quote.");
                Assert.Null(deletedQuote); // The quote should no longer exist in the database
            }
    }
    
}