namespace CarRentalSystem.Identity.API
{
    using CarRentalSystem.Common.Configurations;
    using CarRentalSystem.Identity.API.Configurations;
    using CarRentalSystem.Identity.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDatabase<IdentityContext>(this.Configuration)
                .AddApplicationSettings(this.Configuration)
                .AddTokenAuthentication(this.Configuration)
                .AddIdentity()
                .AddServices()
                .AddHealthChecker(this.Configuration)
                .AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
            => app
                .UseWebService(env)
                .UseDatabaseMigrate();
    }
}
