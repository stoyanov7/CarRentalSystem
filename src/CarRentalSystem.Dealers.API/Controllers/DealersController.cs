namespace CarRentalSystem.Dealers.API.Controllers
{
    using CarRentalSystem.Common;
    using CarRentalSystem.Common.Controllers;
    using CarRentalSystem.Dealers.API.Models.Dealers;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class DealersController : ApiController
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IDealerService dealerService;

        public DealersController(ICurrentUserService currentUserService, IDealerService dealerService)
        {
            this.currentUserService = currentUserService;
            this.dealerService = dealerService;
        }

        [HttpPost]
        [Authorize]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create([FromQuery] CreateDealerInputModel createDealerInputModel)
        {
            var dealer = new Dealer
            {
                Name = createDealerInputModel.Name,
                PhoneNumber = createDealerInputModel.PhoneNumber,
                UserId = this.currentUserService.UserId
            };

            await this.dealerService.Save(dealer);

            return this.Ok();
        }
    }
}
