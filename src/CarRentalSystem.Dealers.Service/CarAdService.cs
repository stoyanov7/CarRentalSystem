namespace CarRentalSystem.Dealers.Service
{
    using AutoMapper;
    using CarRentalSystem.Dealers.Data;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarAdService : DataService<CarAd>, ICarAdService
    {
        private readonly IMapper mapper;

        public CarAdService(DealersContext dealersContext, IMapper mapper)
            : base(dealersContext)
        {
            this.mapper = mapper;
        }

        public async Task<TModel> GetDetails<TModel>(int id)
            => await this.mapper
                .ProjectTo<TModel>(this.AllAvailable(id))
                .FirstOrDefaultAsync();

        public async Task<CarAd> FindByIdAsync(int id)
            => await this
                .All()
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<bool> Delete(int id)
        {
            var carAd = await this.DealersContext
                .CarAds
                .FindAsync(id);

            if (carAd == null)
            {
                return false;
            }

            this.DealersContext.CarAds.Remove(carAd);
            await this.DealersContext.SaveChangesAsync();

            return true;
        }

        private IQueryable<CarAd> AllAvailable(int id)
            => this
                .All()
                .Where(car => car.IsAvailable)
                .Where(x => x.Id == id);
    }
}
