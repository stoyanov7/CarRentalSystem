namespace CarRentalSystem.Dealers.Data
{
    using CarRentalSystem.Common.Extensions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DealersContext>
    {
        public DealersContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DealersContext>();
            var connectionString = configuration.GetDefaultConnectionString();
            builder.UseSqlServer(connectionString);

            return new DealersContext(builder.Options);
        }
    }
}
