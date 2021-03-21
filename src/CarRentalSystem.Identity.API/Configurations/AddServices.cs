namespace CarRentalSystem.Identity.API.Configurations
{
    using CarRentalSystem.Identity.Services;
    using CarRentalSystem.Identity.Services.Contracts;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ITokenGeneratorService, TokenGeneratorService>();

            return service;
        }
    }
}
