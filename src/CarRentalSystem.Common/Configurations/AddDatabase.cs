namespace CarRentalSystem.Common.Configurations
{
    using CarRentalSystem.Common.Extensions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddDatabase<TDbContext>(this IServiceCollection services, IConfiguration configuration)
            where TDbContext : DbContext
            => services
                .AddScoped<DbContext, TDbContext>()
                .AddDbContextPool<TDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetDefaultConnectionString(),
                        sqlServerOptionsAction => sqlServerOptionsAction.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null)
                        )
                );
    }
}
