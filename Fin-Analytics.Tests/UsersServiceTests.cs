using Microsoft.EntityFrameworkCore;
using Xunit;

public class UsersServiceTests
{
    private readonly UsersService _service;
    private readonly AppDbContext _context;

    public UsersServiceTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new AppDbContext(options);
        _service = new UsersService(_context);
    }

    [Fact]
    public async Task GetUser_ReturnsUser_WhenUserExists()
    {
        // Arrange
        var user = new Users { UserId = 1, FullName = "Test User", DoB = DateTime.Now, Phone = "123456789", Address = "123 Test St", Email = "test@example.com" };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Act
        var result = await _service.GetUser(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test User", result.FullName);
    }

    [Fact]
    public async Task GetUsers_ReturnsAllUsers()
    {
        // Act
        var result = await _service.GetUsers();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Count > 0);
    }

    [Fact]
    public async Task CreateUser_AddsNewUser()
    {
        // Arrange
        var user = new Users { FullName = "New User", DoB = DateTime.Now, Phone = "987654321", Address = "456 New St", Email = "new@example.com" };

        // Act
        var createdUser = await _service.CreateUser(user);

        // Assert
        Assert.NotNull(createdUser);
        Assert.Equal("New User", createdUser.FullName);
    }
}
