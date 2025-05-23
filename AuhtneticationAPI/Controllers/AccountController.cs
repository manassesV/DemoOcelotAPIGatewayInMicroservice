using AuhtneticationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuhtneticationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IConfiguration config) : Controller
    {

        private static ConcurrentDictionary<string, string> UserData { get; set; } = new ConcurrentDictionary<string, string>();


        [HttpPost("login/{email}/{password}")]
        public async Task<ActionResult> Login(string email, string password)
        {
            await Task.Delay(500);

            var getEmail = UserData!.Keys.Where(e => e.Equals(email)).FirstOrDefault();
            if (!string.IsNullOrEmpty(getEmail))
            {
                UserData.TryGetValue(email, out string? dbPassword);
                if (!Equals(dbPassword, password))
                    return BadRequest("Invalid credentials");

                string jwtToken = GenerateToken(getEmail);

                return Ok(jwtToken);
            }

            return NotFound("Email not found");
        }

        private string GenerateToken(string getEmail)
        {
            var key = Encoding.UTF8.GetBytes(config["Authentication:Key"]);
            var securityKey = new SymmetricSecurityKey(key);
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Email, getEmail!)
            };
            var token = new JwtSecurityToken(
                issuer: config["Authentication:Issuer"],
                audience: config["Authentication:Audience"],
                claims: claims,
                expires: null,
                signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("register/{email}/{password}")]
        public async Task<IActionResult> Register(string email, string password)
        {
            await Task.Delay(500);
            var getEmail = UserData!.Keys.Where(e => e.Equals(email)).FirstOrDefault();

            if (!string.IsNullOrEmpty(getEmail))
                return BadRequest("User already exist");

            UserData[email] = password;

            return Ok("User create successfully");
        }
    }
}
