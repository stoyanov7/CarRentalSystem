﻿namespace CarRentalSystem.Common.Configurations
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddHealthChecker(this IServiceCollection services, IConfiguration configuration)
        {
            var healthChecks = services.AddHealthChecks();

            healthChecks
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return services;
        }
    }
}
