namespace CarRentalSystem.Statistics.Data
{
    using CarRentalSystem.Statistics.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class StatisticsContext : DbContext
    {
        public StatisticsContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<CarAdView> CarAdViews { get; set; }

        public DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
