namespace CarRentalSystem.Dealers.API.Controllers
{
    using CarRentalSystem.Common;
    using CarRentalSystem.Common.Controllers;
    using CarRentalSystem.Dealers.API.Models.CarAds;
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
    }
}
