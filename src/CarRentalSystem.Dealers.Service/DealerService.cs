namespace CarRentalSystem.Dealers.Service
{
    using CarRentalSystem.Dealers.Data;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;

    public class DealerService : DataService<Dealer>, IDealerService
    {
        public DealerService(DealersContext dealersContext)
            : base(dealersContext)
        {
        }
    }
}
