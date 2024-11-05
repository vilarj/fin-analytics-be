using Fin_Analytics.Models;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// UsersController class:
/// The UsersController class is an API controller that exposes endpoints for managing user data,
/// leveraging UsersService for database operations. This controller handles HTTP requests and
/// formats the responses accordingly.
/// 
/// Constructor
/// UsersController(UsersService usersService): Injects an instance of UsersService to 
/// interact with the database through service methods.
/// 
/// Endpoints
/// GET /api/users/{userId}: Retrieves a user by userId.
///                     Returns 404 Not Found if no user exists with the given ID,
///                     or 200 OK with user data if found.
/// GET /api/users: Retrieves all users from the database.
///                     Returns 200 OK with a list of users.
/// POST /api/users: Adds a new user to the database. Expects a JSON body with user data. 
///                     Returns 201 Created with the created user
///                     or 400 Bad Request if the data is invalid.
/// POST /api/users/batch: Adds multiple users in batch to the database. Expects a JSON array of user data.
///                     Returns 200 OK with the created users
///                     or 400 Bad Request if data is empty or invalid.
/// </summary>
namespace Fin_Analytics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _usersService.GetUser(userId);

            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usersService.GetUsers();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Users newUser)
        {
            if (newUser == null)
            {
                return BadRequest("User data is null");
            }

            var createdUser = await _usersService.CreateUser(newUser);

            return CreatedAtAction(nameof(GetUser), new { userId = createdUser.UserId }, createdUser);
        }

        [HttpPost("batch")]
        public async Task<IActionResult> CreateUsers([FromBody] List<Users> newUsers)
        {
            if (newUsers == null || newUsers.Count == 0)
            {
                return BadRequest("User data is null or empty");
            }

            var createdUsers = await _usersService.CreateUsers(newUsers);

            return Ok(createdUsers);
        }
    }
}
