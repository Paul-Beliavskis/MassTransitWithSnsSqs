using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShipmentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ShipmentController> _logger;

        public ShipmentController(ILogger<ShipmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "";
        }
    }
}
