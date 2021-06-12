namespace CarRentalSystem.Schedule.API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using CarRentalSystem.Common.Configurations;
    using CarRentalSystem.Schedule.Data;
    using Microsoft.Extensions.Configuration;
    using CarRentalSystem.Schedule.Services.Contracts;
    using CarRentalSystem.Schedule.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase<ScheduleDbContext>(this.Configuration)
                .AddTransient<IRentedCarService, RentedCarService>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .UseDatabaseMigrate();
        
    }
}
