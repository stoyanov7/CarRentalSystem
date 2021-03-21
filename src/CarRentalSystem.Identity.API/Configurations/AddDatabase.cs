namespace CarRentalSystem.Identity.API.Configurations
{
    using CarRentalSystem.Identity.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection service, IConfiguration configuration)
        {
            service
                .AddScoped<DbContext, IdentityContext>()
                .AddDbContextPool<IdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return service;
        }
    }
}
