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

        /// <summary>
        /// Represents the user service.
        /// </summary>
        public UsersService(AppDbContext context)
        {
            _context = context;
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
        /// Creates a new user.
        /// </summary>
        /// <param name="newUser">The new user to create.</param>
        /// <returns>
        /// The newly created user.
        /// </returns>
        public async Task<Users> CreateUser(Users newUser)
        {
            newUser.CreatedOn = DateTime.Now;
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        /// <summary>
        /// Creates multiple users in a batch operation.
        /// </summary>
        /// <param name="newUsers">A list of new users to create.</param>
        /// <returns>
        /// The list of newly created users.
        /// </returns>
        public async Task<List<Users>> CreateUsers(List<Users> newUsers)
        {
            _context.Users.AddRange(newUsers);
            await _context.SaveChangesAsync();

            return newUsers;
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
            if (!string.IsNullOrEmpty(updatedUser.FullName)) user.FullName = updatedUser.FullName;
            if (!string.IsNullOrEmpty(updatedUser.Phone)) user.Phone = updatedUser.Phone;

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
    }
}