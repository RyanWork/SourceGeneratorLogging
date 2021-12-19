# SourceGeneratorLogging
Logging using source generators. Has about a 2x-3x performance increase. 

|                 Method |          fakeContext |      Mean |    Error |   StdDev |
|----------------------- |--------------------- |----------:|---------:|---------:|
| SourceGeneratedLogging | Micro(...)ntext [44] |  44.38 ns | 0.119 ns | 0.111 ns |
|         ClassicLogging | Micro(...)ntext [44] | 111.65 ns | 0.335 ns | 0.314 ns |


Sources from: 
* https://andrewlock.net/exploring-dotnet-6-part-8-improving-logging-performance-with-source-generators/
* https://docs.microsoft.com/en-us/dotnet/core/extensions/logger-message-generator
