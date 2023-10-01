using NBench;
using System.Net.Http;
using BenchmarkDotNet.Attributes;
using IQuotes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.IsisMtt.Ocsp;

namespace StressTest;

[MemoryDiagnoser]
public class GetRequestTest
{
    private static HttpClient _httpClient;
    [GlobalSetup]
    public void GlobalSetup()
    {
        System.Diagnostics.Debugger.Launch();
        // Initialize resources or setup code here
        //_operationsCounter = context.GetCounter("Operations Counter");
        var _factory = new WebApplicationFactory<Startup>().WithWebHostBuilder(
            configuration=>configuration.ConfigureLogging(logging=>
                logging.ClearProviders()
                ));
        _httpClient = _factory.CreateClient();
    }

    [Benchmark]
    public async Task GetResponseTime()
    {
       var response= await _httpClient.GetAsync("/");
    }
}


