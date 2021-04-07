namespace CarRentalSystem.Statistics.API.Controllers
{
    using CarRentalSystem.Common.Controllers;
    using CarRentalSystem.Statistics.API.Models;
    using CarRentalSystem.Statistics.Service.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CarAdViewsController : ApiController
    {
        private readonly ICarAdViewService carAdViewService;

        public CarAdViewsController(ICarAdViewService carAdViewService)
            => this.carAdViewService = carAdViewService;

        [HttpGet]
        [Route(nameof(TotalViews) + PathSeparator + Id)]
        public async Task<int> TotalViews(int id) => await this.carAdViewService.GetTotalViews(id);

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<CarAdViewOutputModel>> TotalViews([FromQuery] IEnumerable<int> ids)
            => await this.carAdViewService.GetTotalViews<CarAdViewOutputModel>(ids);
    }
}
