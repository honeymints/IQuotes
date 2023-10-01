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
}