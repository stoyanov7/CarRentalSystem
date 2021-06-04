namespace CarRentalSystem.Statistics.API
{
    using CarRentalSystem.Common.Configurations;
    using CarRentalSystem.Statistics.API.Configurations;
    using CarRentalSystem.Statistics.API.Messages;
    using CarRentalSystem.Statistics.Data;
    using CarRentalSystem.Statistics.Service;
    using CarRentalSystem.Statistics.Service.Contracts;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase<StatisticsContext>(this.Configuration)
                .AddApplicationSettings(this.Configuration)
                .AddTokenAuthentication(this.Configuration)
                .AddHealthChecker(this.Configuration)
                .AddTransient<IStatisticsService, StatisticsService>()
                .AddTransient<ICarAdViewService, CarAdViewService>()
                .AddMessaging(typeof(CarAdCreatedConsumer))
                .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
                .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .UseDatabaseMigrate()
                .UseSeedData();
        
    }
}
