using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApplication.Middleware
{
    public partial class RequestLoggingMiddleware
    {
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(ILogger<RequestLoggingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            LogHttpRequest(httpContext.Connection.RemoteIpAddress?.ToString());
            await _next(httpContext);
        }
        
        public async Task InvokeAsyncClassic(HttpContext httpContext)
        {
            _logger.LogInformation(string.Format("Received request from {0}", httpContext.Connection.RemoteIpAddress));
            await _next(httpContext);
        }
        
        [LoggerMessage(
            EventId = 0,
            Level = LogLevel.Information,
            Message = "Received request from {ipAddress}")]
        partial void LogHttpRequest(string? ipAddress);
    }
}