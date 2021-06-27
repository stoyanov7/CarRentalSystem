namespace CarRentalSystem.Dealers.Data
{
    using CarRentalSystem.Common.Extensions;
    using CarRentalSystem.Schedule.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ScheduleDbContext>
    {
        public ScheduleDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ScheduleDbContext>();
            var connectionString = configuration.GetDefaultConnectionString();
            builder.UseSqlServer(connectionString);

            return new ScheduleDbContext(builder.Options);
        }
    }
}
