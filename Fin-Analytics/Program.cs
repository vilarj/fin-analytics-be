using Fin_Analytics;
using Fin_Analytics.FinAnalyticsDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register controller services
builder.Services.AddControllers();
builder.Services.AddScoped<UsersService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=../Database/FinAnalyticsDB.db"));

var app = builder.Build();

// Use HTTPS Redirection
app.UseHttpsRedirection();

// Map controllers
app.MapControllers();

app.Run();
