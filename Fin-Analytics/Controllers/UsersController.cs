using Fin_Analytics.Models;
using Fin_Analytics.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fin_Analytics.Controllers
{
    /// <summary>
    /// <b>UsersController</b> class is an API controller that exposes endpoints for managing user data,
    /// leveraging UsersService for database operations. This controller handles HTTP requests and
    /// formats the responses accordingly.
    /// 
    /// <para><c>Constructor:</c></para>
    /// Injects an instance of UsersService to 
    /// interact with the database through service methods. 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UsersService _usersService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="usersService">The user service.</param>
        /// <param name="logger"></param>
        public UsersController(UsersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>
        /// Returns an HTTP 200 OK response with the user information if found.
        /// Returns an HTTP 404 Not Found response if the user is not found.
        /// </returns>
        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            _logger.LogInformation("Getting user with ID {UserId}", userId);

            var user = await _usersService.GetUser(userId);

            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            return Ok(user);
        }

        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        /// <returns>
        /// An HTTP 200 OK response with a list of all users.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            _logger.LogInformation("Getting all users");

            var users = await _usersService.GetUsers();

            return Ok(users);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="newUser">The new user to create.</param>
        /// <returns>
        /// Returns an HTTP 201 Created response with the newly created user.
        /// Returns an HTTP 400 Bad Request response if the `newUser` object is null.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Users newUser)
        {
            if (newUser == null)
            {
                _logger.LogInformation($"Bad Request:\nUser data is null.");

                return BadRequest("User data is null");
            }

            var createdUser = await _usersService.CreateUser(newUser);

            return CreatedAtAction(nameof(GetUser), new { userId = createdUser.UserId }, createdUser);
        }

        /// <summary>
        /// Creates multiple users in a batch operation.
        /// </summary>
        /// <param name="newUsers">A list of new user objects to create.</param>
        /// <returns>
        /// Returns an HTTP 200 OK response with a list of created users if successful.
        /// Returns an HTTP 400 Bad Request response if the `newUsers` list is null or empty.
        /// </returns>
        [HttpPost("batch")]
        public async Task<IActionResult> CreateUsers([FromBody] List<Users> newUsers)
        {
            if (newUsers == null || newUsers.Count == 0)
            {
                _logger.LogInformation("Bad Request:\nUser data is null or empty");

                return BadRequest("User data is null or empty");
            }

            var createdUsers = await _usersService.CreateUsers(newUsers);

            _logger.LogInformation("A batch of users were created successfully.");

            return Ok(createdUsers);
        }

        /// <summary>
        /// Updates specific details of a user, such as address, company, full name, or phone.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="updatedUser">An object containing the fields to update.</param>
        /// <returns>
        /// Returns an HTTP 200 OK response with a success message if the user is updated successfully.
        /// Returns an HTTP 404 Not Found response if the user is not found.
        /// </returns>
        [HttpPut("{userId:int}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] Users updatedUser)
        {
            _logger.LogInformation($"Updating UserId {userId}.");

            var result = await _usersService.UpdateUser(userId, updatedUser);

            return result ?? NotFound($"User with ID {userId} not found.");
        }

        /// <summary>
        /// Updates specific details of a user, such as address, company, full name, or phone.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="updatedUser">An object containing the fields to update.</param>
        /// <returns>
        /// Returns an HTTP 200 OK response with a success message if the user is updated successfully.
        /// Returns an HTTP 404 Not Found response if the user is not found.
        /// </returns>
        [HttpPut("UpdateFirst/{userId:int}")]
        public async Task<IActionResult> UpdateFirstName(int userId, [FromBody] string firstName)
        {
            _logger.LogInformation($"Updating UserId {userId}.");

            var result = await _usersService.UpdateFirstName(userId, firstName);

            return result ?? NotFound($"User with ID {userId} not found.");
        }

        /// <summary>
        /// Deletes a single user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>
        /// Returns an HTTP 200 OK response with a success message if the user is deleted successfully.
        /// Returns an HTTP 404 Not Found response if the user is not found.
        /// </returns>
        [HttpDelete("{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            _logger.LogInformation($"Deleting UserId {userId}.");

            var result = await _usersService.DeleteUser(userId);

            return result ?? NotFound($"User with ID {userId} not found.");
        }

        /// <summary>
        /// Deletes multiple users by their IDs.
        /// </summary>
        /// <param name="userIds">A list of user IDs to delete.</param>
        /// <returns>
        /// Returns an HTTP 200 OK response with a success message if users are deleted successfully.
        /// Returns an HTTP 404 Not Found response if none of the specified users are found.
        /// </returns>
        [HttpDelete("batch")]
        public async Task<IActionResult> DeleteUsers([FromBody] List<int> userIds)
        {
            _logger.LogInformation($"Deleting a batch of users.");

            var result = await _usersService.DeleteUsers(userIds);

            return result ?? NotFound("None of the specified users were found.");
        }
    }
}