namespace CarRentalSystem.Dealers.API.Configurations
{
    using CarRentalSystem.Common.Services.Contracts;
    using CarRentalSystem.Dealers.Data;
    using CarRentalSystem.Dealers.Service;
    using CarRentalSystem.Dealers.Service.Contracts;
    using Microsoft.Extensions.DependencyInjection;

    internal static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service
                .AddTransient<ICarAdService, CarAdService>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IDealerService, DealerService>()
                .AddTransient<IManufacturerService, ManufacturerService>()
                .AddTransient<IDataSeeder, DealersDataSeeder>();

            return service;
        }
    }
}
