using Fin_Analytics.Models;
using Microsoft.EntityFrameworkCore;

namespace Fin_Analytics.FinAnalyticsDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        DbSet<Users> Users { get; set; }
    }
}