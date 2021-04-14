namespace CarRentalSystem.Statistics.API
{
    using CarRentalSystem.Common.Configurations;
    using CarRentalSystem.Statistics.API.Configurations;
    using CarRentalSystem.Statistics.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

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
            .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .UseDatabaseMigrate()
                .UseSeedData();
        
    }
}
