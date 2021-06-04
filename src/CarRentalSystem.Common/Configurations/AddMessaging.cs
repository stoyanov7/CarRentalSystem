namespace CarRentalSystem.Common.Configurations
{
    using CarRentalSystem.Infrastructure;
    using GreenPipes;
    using MassTransit;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, params System.Type[] consumers)
            => services.AddMassTransit(mt =>
            {
                consumers.ForEach(consumer => mt.AddConsumer(consumer));

                mt.AddBus(bus => Bus.Factory.CreateUsingRabbitMq(rmq =>
                {
                    rmq.Host("rabbitmq", host =>
                    {
                        host.Username("rabbitmq");
                        host.Password("rabbitmq");
                    });

                    consumers.ForEach(consumer => rmq.ReceiveEndpoint(consumer.FullName, endpoint =>
                    {
                        endpoint.PrefetchCount = 6;
                        endpoint.UseMessageRetry(retry => retry.Interval(10, 1000));

                        endpoint.ConfigureConsumer(bus, consumer);
                    }));
                }));
            })
            .AddMassTransitHostedService();
    }
}
