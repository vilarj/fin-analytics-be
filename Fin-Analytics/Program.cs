var builder = WebApplication.CreateBuilder(args);

// Register controller services
builder.Services.AddControllers();

var app = builder.Build();

// Use HTTPS Redirection
app.UseHttpsRedirection();

// Map controllers
app.MapControllers();

app.Run();
