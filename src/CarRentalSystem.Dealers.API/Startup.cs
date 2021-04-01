namespace CarRentalSystem.Dealers.API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using CarRentalSystem.Common.Configurations;
    using CarRentalSystem.Dealers.API.Configurations;
    using CarRentalSystem.Dealers.Data;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
            => services
            .AddDatabase<DealersContext>(this.Configuration)
            .AddApplicationSettings(this.Configuration)
            .AddTokenAuthentication(this.Configuration)
            .AddControllers();

       public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .UseDatabaseMigrate()
                .UseSeedData();
        
    }
}
