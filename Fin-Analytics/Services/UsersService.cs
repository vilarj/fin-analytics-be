using Fin_Analytics.FinAnalyticsDbContext;
using Fin_Analytics.Models;
using Microsoft.EntityFrameworkCore;

namespace Fin_Analytics;

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
}
