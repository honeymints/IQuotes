// See https://aka.ms/new-console-template for more information


using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using StressTest;

public class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<GetRequestTest>();
        BenchmarkRunner.Run<UserRegistrationBenchmark>();
    }
    /*static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());*/
}