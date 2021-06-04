namespace CarRentalSystem.Dealers.Service
{
    using AutoMapper;
    using CarRentalSystem.Common.Messages.Dealers;
    using CarRentalSystem.Common.Service;
    using CarRentalSystem.Common.Service.Contracts;
    using CarRentalSystem.Dealers.Data;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarAdService : DataService<CarAd>, ICarAdService
    {
        private const int CarAdsPerPage = 10;

        private readonly IMapper mapper;
        private readonly IDealerService dealerService;
        private readonly ICurrentUserService currentUserService;
        private readonly IManufacturerService manufacturerService;
        private readonly ICategoryService categoryService;
        private readonly IBus publisher;

        public CarAdService(
            DealersContext dealersContext,
            IMapper mapper,
            IDealerService dealerService,
            ICurrentUserService currentUserService,
            IManufacturerService manufacturerService,
            ICategoryService categoryService,
            IBus publisher)
            : base(dealersContext)
        {
            this.mapper = mapper;
            this.dealerService = dealerService;
            this.currentUserService = currentUserService;
            this.manufacturerService = manufacturerService;
            this.categoryService = categoryService;
            this.publisher = publisher;
        }

        public async Task<CarAd> CreateCarAdAsync(string manufacturer, string model, Category category, string imageUrl, decimal pricePerDay, bool hasClimateControl, int numberOfSeats, int transmissionType)
        {
            var dealer = await this.dealerService.FindByUserAsync(this.currentUserService.UserId);

            var foundManufacturer = await this.manufacturerService
                .CreateOrUpdateManufacturer(manufacturer);

            var carAd = new CarAd
            {
                Dealer = dealer,
                Manufacturer = foundManufacturer,
                Model = model,
                Category = category,
                ImageUrl = imageUrl,
                PricePerDay = pricePerDay,
                Options = new Options
                {
                    HasClimateControl = hasClimateControl,
                    NumberOfSeats = numberOfSeats,
                    TransmissionType = (TransmissionType)transmissionType
                }
            };

            await this.Save(carAd);

            await this.publisher.Publish(new CarAdCreatedMessage
            {
                CarAdId = carAd.Id
            });

            return carAd;
        }

        public async Task EditCarAdAsync(int id, int categoryId, string manufacturer, string model, string imageUrl, decimal pricePerDay, bool hasClimateControl, int numberOfSeats, int transmissionType)
        {
            var category = await this.categoryService.FindByIdAsync<Category>(categoryId);
            var foundManufacturer = await this.manufacturerService
                .CreateOrUpdateManufacturer(manufacturer);

            var carAd = await this.FindByIdAsync(id);

            carAd.Manufacturer = foundManufacturer;
            carAd.Model = model;
            carAd.Category = category;
            carAd.ImageUrl = imageUrl;
            carAd.PricePerDay = pricePerDay;
            carAd.Options = new Options
            {
                HasClimateControl = hasClimateControl,
                NumberOfSeats = numberOfSeats,
                TransmissionType = (TransmissionType)transmissionType
            };

            await this.Save(carAd);
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
            var carAd = await this
                .Context
                .FindAsync<CarAd>(id);

            if (carAd == null)
            {
                return false;
            }

            this.Context.Remove(carAd);
            await this.Context.SaveChangesAsync();

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

        public async Task ChangeAvailabilityAsync(int id)
        {
            var carAd = await this.FindByIdAsync(id);
            carAd.IsAvailable = !carAd.IsAvailable;

            await this.Save(carAd);
        }

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
