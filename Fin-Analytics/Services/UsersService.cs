using Fin_Analytics.FinAnalyticsDbContext;
using Fin_Analytics.Models;
using Microsoft.EntityFrameworkCore;

namespace Fin_Analytics;



/// <summary>
/// UsersService class:
/// The UsersService class provides methods to interact with the database for handling Users data. 
/// It is a service layer designed to encapsulate data access logic, separate from the controller logic, 
/// to promote clean architecture.
/// 
/// Constructor 
/// UsersService(AppDbContext context): Initializes a new instance of UsersService with an 
/// AppDbContext instance for database operations.
/// 
/// Methods:
/// 
/// Task<Users?> GetUser(int userId): Retrieves a single user by userId. 
///                                     Returns null if no user is found.
/// Task<List<Users>> GetUsers(): Retrieves all users from the database. 
///                                     Returns a list of Users objects.
/// Task<Users> CreateUser(Users newUser): Adds a new User object to the database. 
///                                         Returns the newly created Users object.
/// Task<List<Users>> CreateUsers(List<Users> newUsers): Adds multiple Users to the database in batch. 
///                                                                 Returns the list of created Users.
/// 
/// </summary>
public class UsersService
{
    private readonly AppDbContext _context;

    public UsersService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Users?> GetUser(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<List<Users>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<Users> CreateUser(Users newUser)
    {
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return newUser;
    }

    public async Task<List<Users>> CreateUsers(List<Users> newUsers)
    {
        _context.Users.AddRange(newUsers);
        await _context.SaveChangesAsync();

        return newUsers;
    }
}
