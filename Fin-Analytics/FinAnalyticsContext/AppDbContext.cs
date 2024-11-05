using Fin_Analytics.Models;
using Microsoft.EntityFrameworkCore;

namespace Fin_Analytics.FinAnalyticsDbContext
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The database context options.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the DbSet for the <see cref="Users"/> entity.
        /// </summary>
        public DbSet<Users> Users { get; set; }
    }
}