namespace CarRentalSystem.Common.Configurations
{
    using CarRentalSystem.Common.Services.Contracts;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ConfigurationExtensions
    {
        public static IApplicationBuilder UseDatabaseMigrate(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            var db = serviceProvider.GetRequiredService<DbContext>();

            db.Database.Migrate();

            var seeders = serviceProvider.GetServices<IDataSeeder>();

            foreach (var seeder in seeders)
            {
                seeder.SeedData();
            }

            return app;
        }
    }
}
