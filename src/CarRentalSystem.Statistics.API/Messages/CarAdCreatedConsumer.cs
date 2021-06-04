namespace CarRentalSystem.Statistics.API.Messages
{
    using CarRentalSystem.Common.Messages.Dealers;
    using CarRentalSystem.Statistics.Service.Contracts;
    using MassTransit;
    using System;
    using System.Threading.Tasks;

    public class CarAdCreatedConsumer : IConsumer<CarAdCreatedMessage>
    {
        private readonly IStatisticsService statisticsService;

        public CarAdCreatedConsumer(IStatisticsService statisticsService)
            => this.statisticsService = statisticsService;

        public async Task Consume(ConsumeContext<CarAdCreatedMessage> context)
            => await this.statisticsService.IncrementCarAd();
    }
}
