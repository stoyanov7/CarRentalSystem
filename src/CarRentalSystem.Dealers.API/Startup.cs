namespace CarRentalSystem.Dealers.API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using CarRentalSystem.Common.Configurations;
    using CarRentalSystem.Dealers.API.Configurations;
    using CarRentalSystem.Dealers.Data;
    using System.Reflection;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase<DealersContext>(this.Configuration)
                .AddApplicationSettings(this.Configuration)
                .AddTokenAuthentication(this.Configuration)
                .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
                .AddServices()
                .AddMessaging(this.Configuration)
                .AddHealthChecker(this.Configuration)
                .AddControllers()
                .AddNewtonsoftJson();

       public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .UseDatabaseMigrate();
        
    }
}
