namespace CarRentalSystem.Dealers.Service
{
    using CarRentalSystem.Dealers.Data;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;

    public class CarAdService : DataService<CarAd>, ICarAdService
    {
        public CarAdService(DealersContext dealersContext)
            : base(dealersContext)
        {
        }
    }
}
