using IQuotes.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using IQuotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
   
    
    public class UpdateQuoteTests
    {
        [Fact]
        public void AddAndUpdateQuotes_ShouldSucceed()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                // Create the database schema
                context.Database.EnsureCreated();

                var quotes = new List<Quotes>
                {
                    new Quotes
                    {
                        Username = "TestUser1",
                        QuoteText = "Quote 1",
                        CreatedAt = DateTime.UtcNow
                    },
                    new Quotes
                    {
                        Username = "TestUser2",
                        QuoteText = "Quote 2",
                        CreatedAt = DateTime.UtcNow
                    }
                };

                // Act: Add quotes to the database
                context.Quotes.AddRange(quotes);
                context.SaveChanges();

                // Assert: Verify the quotes were added
                foreach (var quote in quotes)
                {
                    var savedQuote = context.Quotes.FirstOrDefault(q => q.Username == quote.Username && q.QuoteText == quote.QuoteText);
                    Assert.NotNull(savedQuote);
                }

                // Update quotes
                foreach (var quote in quotes)
                {
                    quote.QuoteText = "Updated " + quote.QuoteText;
                    context.Entry(quote).State = EntityState.Modified;
                }
                context.SaveChanges();

                // Assert: Verify that the quotes have been updated
                foreach (var quote in quotes)
                {
                    var updatedQuote = context.Quotes.SingleOrDefault(q => q.Username == quote.Username && q.QuoteText == "Updated " + quote.QuoteText);
                    Assert.NotNull(updatedQuote);

                    // Expected Result: Verify that the QuoteText property has been updated
                    var expectedResult = "Updated " + quote.QuoteText;
                    var actualResult = updatedQuote.QuoteText;
                    Assert.Equal(expectedResult, actualResult);
                }
            }
        }
    }
}

