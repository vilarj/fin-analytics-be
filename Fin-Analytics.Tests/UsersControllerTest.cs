using Microsoft.Extensions.Logging;
using Moq;

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
    public async Task GetUser_ReturnsOkResult_WhenUserExists()
    {
        // Arrange
        var user = new Users { UserId = 1, FullName = "Test User" };
        _mockService.Setup(s => s.GetUser(1)).ReturnsAsync(user);

        // Act
        var result = await _controller.GetUser(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedUser = Assert.IsType<Users>(okResult.Value);
        Assert.Equal(user.FullName, returnedUser.FullName);
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
    public async Task CreateUser_ReturnsCreatedAtAction_WhenUserIsCreated()
    {
        // Arrange
        var newUser = new Users { FullName = "New User" };
        var createdUser = new Users { UserId = 1, FullName = "New User" };
        _mockService.Setup(s => s.CreateUser(newUser)).ReturnsAsync(createdUser);

        // Act
        var result = await _controller.CreateUser(newUser);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnedUser = Assert.IsType<Users>(createdAtActionResult.Value);
        Assert.Equal("New User", returnedUser.FullName);
    }
}
