﻿namespace CarRentalSystem.Statistics.Data
{
    using CarRentalSystem.Common.Extensions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StatisticsContext>
    {
        public StatisticsContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<StatisticsContext>();
            var connectionString = configuration.GetDefaultConnectionString();
            builder.UseSqlServer(connectionString);

            return new StatisticsContext(builder.Options);
        }
    }
}
