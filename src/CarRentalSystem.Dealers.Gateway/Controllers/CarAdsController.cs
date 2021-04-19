namespace CarRentalSystem.Dealers.Gateway.Controllers
{
    using AutoMapper;
    using CarRentalSystem.Common.Controllers;
    using CarRentalSystem.Dealers.Gateway.Models;
    using CarRentalSystem.Dealers.Gateway.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarAdsController : ApiController
    {
        private readonly ICarAdService carAdService;
        private readonly ICarAdViewService carAdViewService;
        private readonly IMapper mapper;

        public CarAdsController(
            ICarAdService carAdService,
            ICarAdViewService carAdViewService,
            IMapper mapper)
        {
            this.carAdService = carAdService;
            this.carAdViewService = carAdViewService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<IEnumerable<MineCarAdOutputModel>> Mine()
        {
            var mineCarAds = await this.carAdService.Mine();
            var mineCarAdIds = mineCarAds.CarAds.Select(c => c.Id);

            var mineCarAdViews = await this
               .carAdViewService
               .TotalViews(mineCarAdIds);

            var outputMineCarAds = this.mapper
                    .Map<IEnumerable<CarAdOutputModel>, IEnumerable<MineCarAdOutputModel>>(mineCarAds.CarAds)
                    .ToDictionary(c => c.Id);

            var mineCarAdViewsDictionary = mineCarAdViews.ToDictionary(v => v.CarAdId, v => v.TotalViews);

            foreach (var (carAdId, totalViews) in mineCarAdViewsDictionary)
            {
                outputMineCarAds[carAdId].TotalViews = totalViews;
            }

            return outputMineCarAds.Values;
        }
    }
}
