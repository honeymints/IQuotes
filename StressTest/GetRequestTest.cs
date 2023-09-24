using NBench;
using System.Net.Http;

namespace StressTest;

public class GetRequestTest
{

    private const string BaseUrl = "http://localhost:5210";
    private const int ConcurrentUsers = 100; // Number of concurrent users
    private Counter _operationsCounter;

    [PerfSetup]
    public void Setup(BenchmarkContext context)
    {
        // Initialize resources or setup code here
        _operationsCounter = context.GetCounter("Operations Counter");
    }

    [PerfBenchmark(
        Description = "Stress test the HomeController Index action with concurrent users",
        RunMode = RunMode.Iterations,
        NumberOfIterations = 1, // Run the test once
        RunTimeMilliseconds = 10000, // Total run time in milliseconds
        TestMode = TestMode.Test)]
    [CounterThroughputAssertion("Operations Counter", MustBe.GreaterThanOrEqualTo,
        ConcurrentUsers)] // Example assertion
    public void BenchmarkHomeController()
    {
        // Create and start a task for each concurrent user
        var tasks = new Task[ConcurrentUsers];
        var httpClient = new HttpClient();

        for (int i = 0; i < ConcurrentUsers; i++)
        {
            tasks[i] = Task.Run(async () =>
            {
                var response = await httpClient.GetAsync($"{BaseUrl}/Home");
                _operationsCounter.Increment();
                // You can analyze the response or perform other actions here if needed.
            });
        }

        // Wait for all tasks to complete
        Task.WhenAll(tasks).Wait();
    }
}


