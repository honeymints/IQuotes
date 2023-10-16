using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Xunit;

namespace Database.Test;

public class UserTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public UserTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task AddUserToDb()
    {
        var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_fixture.Context), null, null, null, null, null, null, null, null);
    
        var email = "testuser@example.com";
        var password = "TestPassword1!";
    
        var user = new IdentityUser { UserName = email, Email = email };

        // Act: Add the user to the database
        var result = await userManager.CreateAsync(user, password);

        // Assert: Verify the result and check the database for the user
        Assert.True(result.Succeeded);

        var retrievedUser = await userManager.FindByEmailAsync(email);
        Assert.NotNull(retrievedUser);
        Assert.Equal(email, retrievedUser.Email);
    }
}