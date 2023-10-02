```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 5500U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
| Method           | Mean | Error |
|----------------- |-----:|------:|
| Register10Users  |   NA |    NA |
| Register50Users  |   NA |    NA |
| Register100Users |   NA |    NA |

Benchmarks with issues:
  UserRegistrationBenchmark.Register10Users: DefaultJob
  UserRegistrationBenchmark.Register50Users: DefaultJob
  UserRegistrationBenchmark.Register100Users: DefaultJob
