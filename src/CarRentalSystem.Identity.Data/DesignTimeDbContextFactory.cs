namespace CarRentalSystem.Identity.Data
{
    using CarRentalSystem.Common.Extensions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<IdentityContext>();
            var connectionString = configuration.GetDefaultConnectionString();
            builder.UseSqlServer(connectionString);

            return new IdentityContext(builder.Options);
        }
    }
}
