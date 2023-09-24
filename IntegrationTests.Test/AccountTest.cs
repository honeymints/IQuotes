using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IQuotes;
using IQuotes.Data;
using IQuotes.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace IntegrationTests.Test;

public class AccountTest : IClassFixture<WebApplicationFactory<Program>>
{
    
        private readonly WebApplicationFactory<Program> _factory;

        public AccountTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task SignUp_Post_AddsUserToDatabaseAndRedirectsToHomePage()
        {
            // Arrange
            var client = _factory.CreateClient();
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new IQuotes.Controllers.AccountController(dbContext);
                var newUser = new User
                {
                    Username = "TestUser",
                    Email = "test@example.com",
                    Password = "TestPassword123",
                    ConfirmPassword = "TestPassword123"
                };

                // Act
                var signUpResponse = await client.PostAsync("/Account/SignUp", GetUserContent(newUser));
                signUpResponse.EnsureSuccessStatusCode();

                // Assert
                Assert.Equal(HttpStatusCode.Redirect, signUpResponse.StatusCode);
                Assert.Equal("/", signUpResponse.Headers.Location.OriginalString);

                var savedUser = await dbContext.Users.FirstOrDefaultAsync();
                Assert.NotNull(savedUser);
                Assert.Equal("TestUser", savedUser.Username);
                Assert.Equal("test@example.com", savedUser.Email);
                // Add more assertions as needed for the User model
            }
        }

        private static StringContent GetUserContent(User user)
        {
            var json = JsonSerializer.Serialize(user);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }


