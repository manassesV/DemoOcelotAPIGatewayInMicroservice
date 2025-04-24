using Identity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private static readonly string[] Users = new[]
        {
            "Netcode", "Hub", "Fred"
        };

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users);
        }

    }
}
