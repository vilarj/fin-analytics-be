using Fin_Analytics.FinAnalyticsContext;
using Fin_Analytics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fin_Analytics.Services
{
    /// <summary>
    /// UsersService class:
    /// The UsersService class provides methods to interact with the 
    /// database for handling Users data. It is a service layer designed 
    /// to encapsulate data access logic, separate from the 
    /// controller logic, to promote clean architecture.
    /// </summary>
    public class UsersService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UsersService> _logger;

        /// <summary>
        /// Represents the user service.
        /// </summary>
        public UsersService(AppDbContext context, ILogger<UsersService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>
        /// The user with the specified ID, or null if not found.
        /// </returns>
        public async Task<Users?> GetUser(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        /// <returns>
        /// A list of all users.
        /// </returns>
        public async Task<List<Users>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        /// <summary>
        /// Creates a new user in the database if no user with the same userId, lastName, email, and phone number exists.
        /// </summary>
        /// <param name="newUser">The user object containing the details of the user to be created.</param>
        /// <returns>
        /// A task representing the asynchronous operation. 
        /// The task result contains the created user object if successful.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if a user with the same userId, lastName, email, and phone number already exists.
        /// </exception>
        public async Task<Users> CreateUser(Users newUser)
        {
            var duplicate = await IsDuplicateUserAsync(newUser);

            if (duplicate)
            {
                throw new InvalidOperationException(
                    $"A user with the same user id, last name, email, and phone number already exists.");
            }

            newUser.CreatedOn = DateTime.Now;

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        /// <summary>
        /// Creates a batch of users in the database, ensuring no duplicates based on last name, email, and phone number.
        /// Logs or returns the list of users that were skipped due to duplication.
        /// </summary>
        /// <param name="newUsers">The list of user objects to be created.</param>
        /// <returns>
        /// A task representing the asynchronous operation. 
        /// The task result contains a tuple with a list of successfully created users and a list of duplicate users.
        /// </returns>
        public async Task<(List<Users> CreatedUsers, List<Users> DuplicateUsers)> CreateUsers(List<Users> newUsers)
        {
            var usersToCreate = new List<Users>();
            var duplicateUsers = new List<Users>();

            foreach (var newUser in newUsers)
            {
                if (!await IsDuplicateUserAsync(newUser))
                {
                    newUser.CreatedOn = DateTime.Now;
                    usersToCreate.Add(newUser);
                }
                else
                {
                    duplicateUsers.Add(newUser);
                }
            }

            // Add only unique users to the database
            if (usersToCreate.Count != 0)
            {
                _context.Users.AddRange(usersToCreate);
                await _context.SaveChangesAsync();
            }

            // Log duplicates if necessary
            if (duplicateUsers.Count != 0)
            {
                _logger.LogWarning(
                    $"Skipped creating {duplicateUsers.Count} duplicate users: {string.Join(", ", duplicateUsers.Select(u => u.Email))}");
            }

            return (usersToCreate, duplicateUsers);
        }

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="updatedUser">An object containing updated user data.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> with a success message if the update is successful;
        /// otherwise, returns null if the user does not exist.
        /// </returns>
        public async Task<IActionResult?> UpdateUser(int userId, Users updatedUser)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null) return null;
            if (!string.IsNullOrEmpty(updatedUser.Address)) user.Address = updatedUser.Address;
            if (!string.IsNullOrEmpty(updatedUser.Company)) user.Company = updatedUser.Company;
            if (!string.IsNullOrEmpty(updatedUser.FirstName)) user.FirstName = updatedUser.FirstName;
            if (!string.IsNullOrEmpty(updatedUser.MiddleName)) user.MiddleName = updatedUser.MiddleName;
            if (!string.IsNullOrEmpty(updatedUser.LastName)) user.LastName = updatedUser.LastName;
            if (!string.IsNullOrEmpty(updatedUser.Phone)) user.Phone = updatedUser.Phone;

            await _context.SaveChangesAsync();
            return new OkObjectResult("User updated successfully");
        }

        public async Task<IActionResult?> UpdateFirstName(int userId, string firstName)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null) return null;
            if (!string.IsNullOrEmpty(firstName)) user.FirstName = firstName;

            await _context.SaveChangesAsync();
            return new OkObjectResult("User updated successfully");
        }

        /// <summary>
        /// Deletes a single user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> with a success message if the deletion is successful;
        /// otherwise, returns null if the user does not exist.
        /// </returns>
        public async Task<IActionResult?> DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return new OkObjectResult("User deleted successfully");
        }

        /// <summary>
        /// Deletes a batch of users based on a list of user IDs.
        /// </summary>
        /// <param name="userIds">A list of user IDs to delete.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> with a success message if deletion is successful;
        /// otherwise, returns null if no matching users are found.
        /// </returns>
        public async Task<IActionResult?> DeleteUsers(List<int> userIds)
        {
            var users = await _context.Users.Where(u => userIds.Contains(u.UserId)).ToListAsync();
            if (users.Count == 0) return null;

            _context.Users.RemoveRange(users);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Users deleted successfully");
        }

        /// <summary>
        /// Checks if a user with the given unique identifiers exists in the database.
        /// </summary>
        /// <param name="newUser">The user object containing all the attributes of a user.</param>
        /// <returns>
        /// A task representing the asynchronous operation. 
        /// The task result contains <c>true</c> if a matching user exists; otherwise, <c>false</c>.
        /// </returns>
        private async Task<bool> IsDuplicateUserAsync(Users newUser)
        {
            return await _context.Users.AnyAsync(user =>
                user.LastName == newUser.LastName &&
                user.Email == newUser.Email &&
                user.Phone == newUser.Phone);
        }
    }
}