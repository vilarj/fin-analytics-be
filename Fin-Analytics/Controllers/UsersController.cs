using Fin_Analytics.FinAnalyticsDbContext;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetUsers()
        {
            return Ok("Get Users");
        }

        [HttpPost]
        public IActionResult CreateUser()
        {
            return Ok("Create Users");
        }
    }
}