namespace CarRentalSystem.Common.Configurations
{
    using CarRentalSystem.Common.MappingProfiles;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Reflection;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddAutoMapperProfile(this IServiceCollection services, Assembly assembly)
            => services
                .AddAutoMapper((_, config) => config.AddProfile(new MappingProfile(assembly)), Array.Empty<Assembly>());
    }
}
