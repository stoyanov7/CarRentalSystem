namespace CarRentalSystem.Dealers.Service
{
    using AutoMapper;
    using CarRentalSystem.Dealers.Data;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarAdService : DataService<CarAd>, ICarAdService
    {
        private const int CarAdsPerPage = 10;

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

        public async Task<IEnumerable<TModel>> GetListings<TModel>(ICarAdsDto query)
           => (await this.mapper
               .ProjectTo<TModel>(this.GetCarAdsQuery(query))
               .ToListAsync())
               .Skip((query.Page - 1) * CarAdsPerPage)
               .Take(CarAdsPerPage);

        public async Task<int> Total(ICarAdsDto query)
            => await this
                .GetCarAdsQuery(query)
                .CountAsync();

        public async Task<IEnumerable<TModel>> Mine<TModel>(int dealerId, ICarAdsDto query)
            => (await this.mapper
                .ProjectTo<TModel>(this.GetCarAdsQuery(query, dealerId))
                .ToListAsync())
                .Skip((query.Page - 1) * CarAdsPerPage)
                .Take(CarAdsPerPage);

        private IQueryable<CarAd> AllAvailable(int id)
            => this
                .All()
                .Where(car => car.IsAvailable)
                .Where(x => x.Id == id);

        private IQueryable<CarAd> GetCarAdsQuery(ICarAdsDto query, int? dealerId = null)
        {
            var dataQuery = this.All();

            if (dealerId.HasValue)
            {
                dataQuery = dataQuery.Where(c => c.DealerId == dealerId);
            }

            if (query.Category.HasValue)
            {
                dataQuery = dataQuery.Where(c => c.CategoryId == query.Category);
            }

            if (!string.IsNullOrWhiteSpace(query.Manufacturer))
            {
                dataQuery = dataQuery.Where(c => c
                    .Manufacturer.Name.ToLower().Contains(query.Manufacturer.ToLower()));
            }

            return dataQuery;
        }
    }
}
