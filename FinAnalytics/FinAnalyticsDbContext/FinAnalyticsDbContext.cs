using FinAnalytics.Models;
using Microsoft.EntityFrameworkCore;

namespace FinAnalytics.FinAnalyticsDbContext
{
    public class FinAnalyticsDbContext : DbContext
    {
        public FinAnalyticsDbContext(DbContextOptions<FinAnalyticsDbContext> options) : base(options) { }

        DbSet<Users> Users { get; set; }
    }
}