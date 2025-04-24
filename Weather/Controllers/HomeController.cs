using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;

namespace Weather.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Baley", "Hot", "Sweltering", "Scorching"
        };

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureCelsius = Random.Shared.Next(-20, 55),
                Condition = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
