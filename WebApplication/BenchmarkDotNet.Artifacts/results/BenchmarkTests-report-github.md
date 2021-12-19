``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1415 (20H2/October2020Update)
AMD Ryzen 7 3800XT, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
|                 Method |          fakeContext |      Mean |    Error |   StdDev |
|----------------------- |--------------------- |----------:|---------:|---------:|
| SourceGeneratedLogging | Micro(...)ntext [44] |  42.75 ns | 0.271 ns | 0.253 ns |
|         ClassicLogging | Micro(...)ntext [44] | 104.03 ns | 0.848 ns | 0.793 ns |
