using Fin_Analytics.FinAnalyticsDbContext;
using Fin_Analytics.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var timestamp = DateTime.Now.ToString("yyyy-MM-dd");

Log.Logger = new LoggerConfiguration()
    .WriteTo.File($"./Logging/log-{timestamp}.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Registering Serilog
builder.Host.UseSerilog();

// Register controller services
builder.Services.AddControllers();
builder.Services.AddScoped<UsersService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=../Database/FinAnalyticsDB.db"));

var app = builder.Build();

// Adding logging to middleware to track incoming requests
app.Use(async (context, next) =>
{
    Log.Information("Incoming request: {Method} {Path}", context.Request.Method, context.Request.Path);
    await next();
});

// Use HTTPS Redirection
app.UseHttpsRedirection();

// Map controllers
app.MapControllers();

app.Run();
