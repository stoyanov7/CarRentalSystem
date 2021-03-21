namespace CarRentalSystem.Common.Configurations
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
            => services
                .Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)));
    }
}
