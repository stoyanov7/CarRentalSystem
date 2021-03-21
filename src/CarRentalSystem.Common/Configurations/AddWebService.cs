namespace CarRentalSystem.Common.Infrastructure
{
    using CarRentalSystem.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ConfigurationExtensions
    {     
        public static IServiceCollection AddWebService<TDbContext>(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHttpContextAccessor();
            service.AddScoped<ICurrentUserService, CurrentUserService>();

            return service;
        }
    }
}
