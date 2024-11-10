using Fin_Analytics.Controllers;
using Fin_Analytics.Models;
using Fin_Analytics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class UsersControllerTests
{
    private readonly UsersController _controller;
    private readonly Mock<UsersService> _mockService;
    private readonly Mock<ILogger<UsersController>> _mockLogger;

    public UsersControllerTests()
    {
        _mockService = new Mock<UsersService>(MockBehavior.Strict);
        _mockLogger = new Mock<ILogger<UsersController>>();
        _controller = new UsersController(_mockService.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task GetUser_ReturnsUser_WhenUserExists()
    {
        // Arrange
        var existingUser = new Users
        {
            UserId = 1,
            FullName = "Existing User",
            DoB = new DateTime(1985, 5, 15),
            Phone = "987-654-3210",
            Address = "456 Existing St",
            Email = "existinguser@example.com",
            Company = "Existing Company"
        };

        _usersServiceMock.Setup(s => s.GetUserById(1)).ReturnsAsync(existingUser);

        // Act
        var result = await _controller.GetUser(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedUser = Assert.IsType<Users>(okResult.Value);
        Assert.Equal(existingUser.UserId, returnedUser.UserId);
    }

    [Fact]
    public async Task GetUser_ReturnsNotFound_WhenUserDoesNotExist()
    {
        // Arrange
        _mockService.Setup(s => s.GetUser(1)).ReturnsAsync((Users)null);

        // Act
        var result = await _controller.GetUser(1);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task CreateUser_ReturnsCreatedAtActionResult_WithCreatedUser()
    {
        // Arrange
        var newUser = new Users
        {
            UserId = 1,
            FullName = "Test User",
            DoB = new DateTime(1990, 1, 1),
            Phone = "123-456-7890",
            Address = "123 Test Street",
            Email = "testuser@example.com",
            Company = "Test Company"
        };

        _usersServiceMock.Setup(s => s.CreateUser(newUser)).ReturnsAsync(newUser);

        // Act
        var result = await _controller.CreateUser(newUser);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedUser = Assert.IsType<Users>(createdResult.Value);
        Assert.Equal(newUser.UserId, returnedUser.UserId);
    }
}
