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


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost]
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
    }
}