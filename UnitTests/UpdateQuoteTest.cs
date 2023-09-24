using IQuotes.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using IQuotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests;

   
    
    public class UpdateQuoteTests
    {
        [Fact]
        public void AddAndUpdateQuotes_ShouldSucceed()
        {
            // arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                // create the database schema
                context.Database.EnsureCreated();

                var quotes = new List<Quotes>
                {
                    new Quotes
                    {
                        User = new User(),
                        QuoteText = "Quote 1",
                        CreatedAt = DateTime.UtcNow
                    },
                    new Quotes
                    {
                        User = new User(),
                        QuoteText = "Quote 2",
                        CreatedAt = DateTime.UtcNow
                    }
                };
                for(int i=0;i<quotes.Count;i++){
                    quotes[i].User.Username = "TextUser";
                }
                // act: 
                context.Quotes.AddRange(quotes);
                context.SaveChanges();

                // assert: verify the quotes were added
                foreach (var quote in quotes)
                {
                    var savedQuote = context.Quotes.FirstOrDefault(q => q.User.Username == quote.User.Username && q.QuoteText == quote.QuoteText);
                    Assert.NotNull(savedQuote);
                }

                // update quotes
                foreach (var quote in quotes)
                {
                    quote.QuoteText = "Updated " + quote.QuoteText;
                    context.Entry(quote).State = EntityState.Modified;
                }
                context.SaveChanges();

                // assert: verify that the quotes have been updated
                foreach (var quote in quotes)
                {
                    var updatedQuote = context.Quotes.SingleOrDefault(q => q.User.Username == quote.User.Username && q.QuoteText == "Updated " + quote.QuoteText);
                    Assert.NotNull(updatedQuote);

                    // expected Result: verify that the QuoteText property has been updated
                    var expectedResult = "Updated " + quote.QuoteText;
                    var actualResult = updatedQuote.QuoteText;
                    Assert.Equal(expectedResult, actualResult);
                }
            }
        }
    }


