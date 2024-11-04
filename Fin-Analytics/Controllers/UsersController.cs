using Fin_Analytics.FinAnalyticsDbContext;
using Fin_Analytics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fin_Analytics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetUsers(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound($"The user of id {userId} was not found");
            }

            return Ok(user);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] Users newUser)
        {
            if (newUser == null)
            {
                return BadRequest("User data is null");
            }

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers), new { id = newUser.UserId }, newUser);
        }

        [HttpPost("BatchOfUsers")]
        public async Task<IActionResult> CreateUsers([FromBody] List<Users> newUsers)
        {
            if (newUsers == null || newUsers.Count == 0)
            {
                return BadRequest("User data is null or empty");
            }

            foreach (var user in newUsers)
            {
                _context.Users.Add(user);
            }

            await _context.SaveChangesAsync();
            return Ok("Users created successfully");
        }
    }
}