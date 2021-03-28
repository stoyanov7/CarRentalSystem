namespace CarRentalSystem.Dealers.Data
{
    using CarRentalSystem.Dealers.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class DealersContext : DbContext
    {
        public DealersContext(DbContextOptions<DealersContext> options)
            : base(options)
        {
        }

        public DbSet<CarAd> CarAds { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Dealer> Dealers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
