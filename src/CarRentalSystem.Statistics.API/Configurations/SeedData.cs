namespace CarRentalSystem.Statistics.API.Configurations
{
    using CarRentalSystem.Statistics.Data;
    using CarRentalSystem.Statistics.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    internal static partial class ConfigurationExtensions
    {
        public static IApplicationBuilder UseSeedData(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            var db = serviceProvider.GetRequiredService<StatisticsContext>();

            if (db.Statistics.Any())
            {
                return app;
            }

            db.Statistics.Add(new Statistics
            {
                TotalCarAds = 0,
                TotalRentedCars = 0
            });

            db.SaveChanges();

            return app;
        }
    }
}
