using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
namespace Integration.Test.IntegrationTests;


public class AccountTests : IClassFixture<WebApplicationFactory<Startup>>
{
    
        private readonly WebApplicationFactory<Startup> _factory;

        public AccountTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        
        [Theory]
        [InlineData("/")]
        [InlineData("/Account/SignUp")]
        
        public async Task Get_SignUpEndpointsAndCorrectContentType(string url)
        {
           
            //Arrange
            var client = _factory.CreateClient();
            
            // Act
            var response = await client.GetAsync(url);
            
            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());

        }
        
}


