namespace CarRentalSystem.Common.Configurations
{
    using CarRentalSystem.Common.Extensions;
    using CarRentalSystem.Common.Messages;
    using CarRentalSystem.Infrastructure;
    using GreenPipes;
    using Hangfire;
    using MassTransit;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddMessaging(
            this IServiceCollection services,
            IConfiguration configuration,
            params System.Type[] consumers)
        {
            services.AddMassTransit(mt =>
            {
                consumers.ForEach(consumer => mt.AddConsumer(consumer));

                mt.AddBus(bus => Bus.Factory.CreateUsingRabbitMq(rmq =>
                {
                    rmq.Host("rabbitmq", host =>
                    {
                        host.Username("rabbitmq");
                        host.Password("rabbitmq");
                    });

                    rmq.UseHealthCheck(bus);

                    consumers.ForEach(consumer => rmq.ReceiveEndpoint(consumer.FullName, endpoint =>
                    {
                        endpoint.PrefetchCount = 6;
                        endpoint.UseMessageRetry(retry => retry.Interval(10, 1000));

                        endpoint.ConfigureConsumer(bus, consumer);
                    }));
                }));
            })
            .AddMassTransitHostedService();

            services.AddHangfire(config => config
                     .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                     .UseSimpleAssemblyNameTypeSerializer()
                     .UseRecommendedSerializerSettings()
                     .UseSqlServerStorage(configuration.GetDefaultConnectionString()));

            services.AddHangfireServer();
            services.AddHostedService<MessagesHostedService>();

            return services;
        }
    }
}
