using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Smoke.Tests;

public class BasicTests : IClassFixture<WebApplicationFactory<Startup>>
{
    
    private readonly WebApplicationFactory<Startup> _factory;


    public BasicTests(WebApplicationFactory<Startup> factory)
    {
            _factory = factory;
    }

    [Fact]
    public async Task Authenticate_Test()
    {
            var client = _factory.CreateClient();
            var userManager = _factory.Services.GetRequiredService<UserManager<IdentityUser>>();
            var testUser = new IdentityUser
            {
                Email = "testemail@gmail.com",
                UserName = "testuser123"
            };
            var password = "testpassword";

            await userManager.CreateAsync(testUser, password);

            //act: registration proccess
            var registerResponse = await client.PostAsync("/Account/SignUp", new FormUrlEncodedContent
            (new[] 
            {
                new KeyValuePair<string, string>("Input.Email", testUser.Email),
                new KeyValuePair<string, string>("Input.Password", password),
                new KeyValuePair<string, string>("Input.Username", testUser.UserName) }));
            Assert.Equal(HttpStatusCode.OK, registerResponse.StatusCode);
    }
}
