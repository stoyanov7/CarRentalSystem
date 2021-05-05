namespace CarRentalSystem.Dealers.Gateway
{
    using CarRentalSystem.Common.Configurations;
    using CarRentalSystem.Common.Extensions;
    using CarRentalSystem.Common.Services;
    using CarRentalSystem.Common.Services.Contracts;
    using CarRentalSystem.Dealers.Gateway.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Refit;
    using System.Reflection;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddRefitClient<ICarAdService>()
                .WithConfiguration(serviceEndpoints.Dealers);

            services
                .AddRefitClient<ICarAdViewService>()
                .WithConfiguration(serviceEndpoints.Statistics);

            services
                .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
                .AddTokenAuthentication(this.Configuration)
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddTransient<JwtHeaderAuthenticationMiddleware>()
                .AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseJwtHeaderAuthentication()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
