using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Integration.Test.IntegrationTests;

public class AutenticationTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;
    
    public AutenticationTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task SignUp_ValidUser_ReturnsRedirectToHome()
    {
        // Arrange
        var client = _factory.CreateClient();
        var signUpUrl = "/Account/SignUp";

        var signUpData = new
        {
            Username = "TestUser",
            Email = "test@example.com",
            Password = "TestPassword1!",
            ConfirmPassword = "TestPassword1!"
        };

        var content = new FormUrlEncodedContent(new[] {
            new KeyValuePair<string, string>("Input.Email", signUpData.Email),
            new KeyValuePair<string, string>("Input.Password", signUpData.Password),
            new KeyValuePair<string, string>("Input.Username", signUpData.Username),
            new KeyValuePair<string, string>("Input.ConfirmPassword", signUpData.ConfirmPassword)
    });

        
        
        // Act
        var response = await client.PostAsync(signUpUrl, content);

        // Assert
        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        //Assert.Equal(HttpStatusCode.Redirect, response.StatusCode); Assert.Equal("/Home", response.Headers.Location.LocalPath);
    }

    [Fact]
    public async Task SignUp_InvalidUser_ReturnsBadRequest()
    {
        // Arrange
        var client = _factory.CreateClient();
        var signUpUrl = "/Account/SignUp";

        var signUpData = new
        {
            Username = "TestUser",
            // invalid email address
            Email = "invalidemail",
            Password = "Short", // password too short
            ConfirmPassword = "PasswordMismatch" // passwords don't match
        };

        var content = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(signUpData),
            Encoding.UTF8,
            "application/json");

        // Act
        var response = await client.PostAsync(signUpUrl, content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
