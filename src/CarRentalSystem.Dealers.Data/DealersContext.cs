namespace CarRentalSystem.Dealers.Data
{
    using CarRentalSystem.Common.Data;
    using CarRentalSystem.Dealers.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class DealersContext : MessageContext
    {
        public DealersContext(DbContextOptions<DealersContext> options)
            : base(options)
        {
        }

        public DbSet<CarAd> CarAds { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Dealer> Dealers { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();
    }
}
