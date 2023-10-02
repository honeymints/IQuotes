```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 5500U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
| Method          | Mean     | Error   | StdDev  | Gen0    | Gen1   | Allocated |
|---------------- |---------:|--------:|--------:|--------:|-------:|----------:|
| GetResponseTime | 152.2 μs | 2.60 μs | 2.99 μs | 12.6953 | 0.4883 |  28.08 KB |
