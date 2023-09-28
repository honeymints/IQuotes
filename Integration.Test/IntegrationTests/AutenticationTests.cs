using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Integration.Test.IntegrationTests;

public class AutenticationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public AutenticationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
}