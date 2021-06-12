namespace CarRentalSystem.Schedule.API.Messages
{
    using CarRentalSystem.Common.Messages.Dealers;
    using CarRentalSystem.Schedule.Services.Contracts;
    using MassTransit;
    using System.Threading.Tasks;

    public class CarAdUpdatedConsumer : IConsumer<CarAdUpdatedMessage>
    {
        private readonly IRentedCarService rentedCarService;

        public CarAdUpdatedConsumer(IRentedCarService rentedCarService)
            => this.rentedCarService = rentedCarService;

        public async Task Consume(ConsumeContext<CarAdUpdatedMessage> context)
            => await this.rentedCarService.UpdateInformation(
                context.Message.CarAdId,
                context.Message.Manufacturer,
                context.Message.Model);
    }
}
