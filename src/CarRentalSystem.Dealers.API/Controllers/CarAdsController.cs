namespace CarRentalSystem.Dealers.API.Controllers
{
    using CarRentalSystem.Common;
    using CarRentalSystem.Common.Controllers;
    using CarRentalSystem.Dealers.API.Models.CarAds.OutputModels;
    using CarRentalSystem.Dealers.API.Models.CarAds.InputModels;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CarAdsController : ApiController
    {
        private readonly IDealerService dealerService;
        private readonly ICurrentUserService currentUserService;
        private readonly ICategoryService categoryService;
        private readonly IManufacturerService manufacturerService;
        private readonly ICarAdService carAdService;

        public CarAdsController(
            IDealerService dealerService,
            ICurrentUserService currentUserService,
            ICategoryService categoryService,
            IManufacturerService manufacturerService,
            ICarAdService carAdService)
        {
            this.dealerService = dealerService;
            this.currentUserService = currentUserService;
            this.categoryService = categoryService;
            this.manufacturerService = manufacturerService;
            this.carAdService = carAdService;
            
        }

        [HttpPost]
        [Authorize]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateCarAdOutputModel>> Create(CarAdInputModel carAdInputModel)
        {
            var dealer = await this.dealerService.FindByUserAsync(this.currentUserService.UserId);
            var category = await this.categoryService.FindByIdAsync<Category>(carAdInputModel.Category);

            if (category == null)
            {
                return this.BadRequest(Result.Failure("Category does not exist."));
            }

            var manufacturer = await this.manufacturerService
                .FindByNameAsync<Manufacturer>(carAdInputModel.Manufacturer);

            manufacturer ??= new Manufacturer
            {
                Name = carAdInputModel.Manufacturer
            };


            var carAd = new CarAd
            {
                Dealer = dealer,
                Manufacturer = manufacturer,
                Model = carAdInputModel.Model,
                Category = category,
                ImageUrl = carAdInputModel.ImageUrl,
                PricePerDay = carAdInputModel.PricePerDay,
                Options = new Options
                {
                    HasClimateControl = carAdInputModel.HasClimateControl,
                    NumberOfSeats = carAdInputModel.NumberOfSeats,
                    TransmissionType = carAdInputModel.TransmissionType
                }
            };

            await this.carAdService.Save(carAd);

            return new CreateCarAdOutputModel(carAd.Id);
        }

        [HttpPost]
        [Authorize]
        [Route(nameof(Edit) + PathSeparator + Id)]
        public async Task<ActionResult> Edit(int id, CarAdInputModel carAdInputModel)
        {
            var dealerId = await this.dealerService.GetDealerIdByUserIdAsync(this.currentUserService.UserId);
            var dealerHasCar = await this.dealerService.HasCarAd(dealerId, id);

            if (!dealerHasCar)
            {
                return this.BadRequest(Result.Failure("You cannot edit this car ad."));
            }

            var category = await this.categoryService.FindByIdAsync<Category>(carAdInputModel.Category);
            var manufacturer = await this.manufacturerService
                .FindByNameAsync<Manufacturer>(carAdInputModel.Manufacturer);

            manufacturer ??= new Manufacturer
            {
                Name = carAdInputModel.Manufacturer
            };

            var carAd = await this.carAdService.FindByIdAsync(id);

            carAd.Manufacturer = manufacturer;
            carAd.Model = carAdInputModel.Model;
            carAd.Category = category;
            carAd.ImageUrl = carAdInputModel.ImageUrl;
            carAd.PricePerDay = carAdInputModel.PricePerDay;
            carAd.Options = new Options
            {
                HasClimateControl = carAdInputModel.HasClimateControl,
                NumberOfSeats = carAdInputModel.NumberOfSeats,
                TransmissionType = carAdInputModel.TransmissionType
            };

            await this.carAdService.Save(carAd);

            return Result.Success;
        }

        [HttpDelete]
        [Authorize]
        [Route(nameof(Delete) + PathSeparator + Id)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var dealerId = await this.dealerService.GetDealerIdByUserIdAsync(this.currentUserService.UserId);

            var dealerHasCar = await this.dealerService.HasCarAd(dealerId, id);

            if (!dealerHasCar)
            {
                return this.BadRequest(Result.Failure("You cannot edit this car ad."));
            }

            return await this.carAdService.Delete(id);
        }

        [HttpGet]
        [Route(nameof(Details) + PathSeparator + Id)]
        public async Task<ActionResult<CarAdDetailsOutputModel>> Details(int id)
            => await this.carAdService.GetDetails<CarAdDetailsOutputModel>(id);

        [HttpGet]
        public async Task<ActionResult<SearchCarAdsOutputModel>> Search([FromQuery] CarAdsInputModel query)
        {
            var carAdListings = await this.carAdService.GetListings(query);
            var totalPages = await this.carAdService.Total(query);

            return new SearchCarAdsOutputModel(carAdListings, query.Page, totalPages);
        }

        [HttpPost]
        [Route(nameof(ChangeAvailability) + PathSeparator + Id)]
        public async Task<ActionResult> ChangeAvailability(int id)
        {
            var dealerId = await this.dealerService.GetDealerIdByUserIdAsync(this.currentUserService.UserId);
            var dealerHasCar = await this.dealerService.HasCarAd(dealerId, id);

            if (!dealerHasCar)
            {
                return this.BadRequest(Result.Failure("You cannot edit this car ad."));
            }

            var carAd = await this.carAdService.FindByIdAsync(id);
            carAd.IsAvailable = !carAd.IsAvailable;

            await this.carAdService.Save(carAd);

            return Result.Success;
        }
    }
}
