namespace CarRentalSystem.Dealers.API.Configurations
{
    using CarRentalSystem.Dealers.Service;
    using CarRentalSystem.Dealers.Service.Contracts;
    using Microsoft.Extensions.DependencyInjection;

    internal static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service
                .AddTransient<IDealerService, DealerService>();

            return service;
        }
    }
}
