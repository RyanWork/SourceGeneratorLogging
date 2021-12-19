using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication.Middleware;

namespace WebApplication
{
    public class BenchmarkTests
    {
        private readonly RequestLoggingMiddleware _requestLoggingMiddleware;

        public BenchmarkTests()
        {
            _requestLoggingMiddleware = new RequestLoggingMiddleware(new TestLogger<RequestLoggingMiddleware>(), _ => Task.CompletedTask);
        }

        [Benchmark]
        [ArgumentsSource(nameof(FakeHttpContext))]
        public Task SourceGeneratedLogging(HttpContext fakeContext) => _requestLoggingMiddleware.InvokeAsync(fakeContext);

        [Benchmark]
        [ArgumentsSource(nameof(FakeHttpContext))]
        public Task ClassicLogging(HttpContext fakeContext) => _requestLoggingMiddleware.InvokeAsyncClassic(fakeContext);

        #region Helpers
    
        private static readonly Random Random = new();
    
        public IEnumerable<HttpContext> FakeHttpContext()
        {
            yield return new DefaultHttpContext
            {
                Connection =
                {
                    RemoteIpAddress = new IPAddress(Random.NextInt64(0, 100000))
                }
            };
        }

        #endregion
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            // **** Uncomment for Running Web Host ****
            // var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder();
            //
            // builder.Services
            //     .AddLogging(logging => logging.AddConsole())
            //     .AddControllers();
            // var app = builder.Build();
            //
            // app.MapControllers();
            // app.UseMiddleware<RequestLoggingMiddleware>();
            //
            // app.Run();
        
            // **** Uncomment for Benchmarks ****
            // BenchmarkRunner.Run<BenchmarkTests>();
        }
    }
}