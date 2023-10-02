using BenchmarkDotNet.Attributes;

namespace StressTest;

[MemoryDiagnoser]
public class UserRegistrationBenchmark
{
    private static HttpClient _httpClient;

    [GlobalSetup]
    public void GlobalSetup()
    {
        // Initialize the HttpClient
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5210");
    }

    [Benchmark]
    public async Task Register10Users()
    {
        await RegisterUsersAsync(10);
    }

    [Benchmark]
    public async Task Register50Users()
    {
        await RegisterUsersAsync(50);
    }

    [Benchmark]
    public async Task Register100Users()
    {
        await RegisterUsersAsync(100);
    }

    private async Task RegisterUsersAsync(int numberOfUsers)
    {
        var tasks = new List<Task>();

        for (int i = 0; i < numberOfUsers; i++)
        {
            tasks.Add(RegisterUserAsync(i));
        }

        await Task.WhenAll(tasks);
    }


    private async Task RegisterUserAsync(int userId)
    {
        var registrationData = new
        {
            Username = $"User{userId}",
            Email = $"user{userId}@example.com",
            Password = "TestPassword1!",
            ConfirmPassword = "TestPassword1!"
        };

        using (var content = new FormUrlEncodedContent(new Dictionary<string, string>
               {
                   { "Input.Username", registrationData.Username },
                   { "Input.Email", registrationData.Email },
                   { "Input.Password", registrationData.Password },
                   { "Input.ConfirmPassword", registrationData.ConfirmPassword }
               }))
        {
            var response = await _httpClient.PostAsync("/Account/SignUp", content);

            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"User registration failed for User{userId}: {response.StatusCode}");
            }
        }
    }
}