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
    using System.Collections.Generic;
    using CarRentalSystem.Dealers.API.Models.Categories;
    using CarRentalSystem.Common.Service.Contracts;
    using AutoMapper;

    public class CarAdsController : ApiController
    {
        private readonly IDealerService dealerService;
        private readonly ICurrentUserService currentUserService;
        private readonly ICategoryService categoryService;
        private readonly ICarAdService carAdService;
        private readonly IMapper mapper;

        public CarAdsController(
            IDealerService dealerService,
            ICurrentUserService currentUserService,
            ICategoryService categoryService,
            ICarAdService carAdService,
            IMapper mapper)
        {
            this.dealerService = dealerService;
            this.currentUserService = currentUserService;
            this.categoryService = categoryService;
            this.carAdService = carAdService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateCarAdOutputModel>> Create(CarAdInputModel inputModel)
        {            
            var category = await this.categoryService.FindByIdAsync<Category>(inputModel.Category);

            if (category == null)
            {
                return this.BadRequest(Result.Failure("Category does not exist."));
            }

            var carAd = this.carAdService.CreateCarAdAsync(inputModel.Manufacturer, inputModel.Model, category, inputModel.ImageUrl, inputModel.PricePerDay, inputModel.HasClimateControl, inputModel.NumberOfSeats, inputModel.TransmissionType);

            var model = this.mapper.Map<CreateCarAdOutputModel>(carAd);

            return model;
        }

        [HttpPost]
        [Authorize]
        [Route(nameof(Edit) + PathSeparator + Id)]
        public async Task<ActionResult> Edit(int id, CarAdInputModel inputModel)
        {
            var dealerId = await this.dealerService.GetDealerIdByUserIdAsync(this.currentUserService.UserId);
            var dealerHasCar = await this.dealerService.HasCarAd(dealerId, id);

            if (!dealerHasCar)
            {
                return this.BadRequest(Result.Failure("You cannot edit this car ad."));
            }

            await this.carAdService.EditCarAdAsync(id, inputModel.Category, inputModel.Manufacturer, inputModel.Model, inputModel.ImageUrl, inputModel.PricePerDay, inputModel.HasClimateControl, inputModel.NumberOfSeats, inputModel.TransmissionType);

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
        [Route(nameof(Search))]
        public async Task<ActionResult<SearchCarAdsOutputModel>> Search([FromQuery] CarAdsInputModel query)
        {
            var carAdListings = await this.carAdService.GetListings<CarAdOutputModel>(query);
            var totalPages = await this.carAdService.Total(query);

            return new SearchCarAdsOutputModel(carAdListings, query.Page, totalPages);
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<ActionResult<MineCarAdsOutputModel>> Mine([FromQuery] CarAdsInputModel query)
        {
            var dealerId = await this.dealerService.GetDealerIdByUserIdAsync(this.currentUserService.UserId);
            var carAdListings = await this.carAdService.Mine<MineCarAdOutputModel>(dealerId, query);
            var totalPages = await this.carAdService.Total(query);

            return new MineCarAdsOutputModel(carAdListings, query.Page, totalPages);
        }

        [HttpGet]
        [Route(nameof(Categories))]
        public async Task<IEnumerable<CategoryOutputModel>> Categories()
            => await this.categoryService.GetAll<CategoryOutputModel>();

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

            await this.carAdService.ChangeAvailabilityAsync(id);

            return Result.Success;
        }
    }
}
