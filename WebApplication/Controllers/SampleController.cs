using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SampleController
    {
        private readonly ILogger<SampleController> _logger;
        
        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult LogSomethingAsync()
        {
            return new OkResult();
        }
    }
}