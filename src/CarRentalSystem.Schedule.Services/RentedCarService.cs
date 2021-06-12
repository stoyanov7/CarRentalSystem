namespace CarRentalSystem.Schedule.Services
{
    using CarRentalSystem.Common.Service;
    using CarRentalSystem.Schedule.Data.Models;
    using CarRentalSystem.Schedule.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class RentedCarService : DataService<RentedCar>, IRentedCarService
    {
        public RentedCarService(DbContext context)
            : base(context)
        {
        }

        public async Task UpdateInformation(int carAdId, string manufacturer, string model)
        {
            var rentedCars = await this
                .All()
                .Where(rc => rc.CarAdId == carAdId)
                .ToListAsync();

            foreach (var rentedCar in rentedCars)
            {
                rentedCar.Information = $"{manufacturer} {model}";
            }

            await this.Context.SaveChangesAsync();
        }
    }
}
