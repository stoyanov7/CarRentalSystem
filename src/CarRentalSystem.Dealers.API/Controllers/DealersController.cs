namespace CarRentalSystem.Dealers.API.Controllers
{
    using CarRentalSystem.Common;
    using CarRentalSystem.Common.Controllers;
    using CarRentalSystem.Dealers.API.Models.Dealers;
    using CarRentalSystem.Dealers.API.Models.Dealers.OutputModels;
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
        public async Task<ActionResult> Create([FromBody] CreateDealerInputModel createDealerInputModel)
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

        [HttpGet]
        [Route("Details/{Id}")]
        public async Task<ActionResult<DealerDetailsOutputModel>> Details(int id)
            => await this.dealerService.GetDetailsAsync<DealerDetailsOutputModel>(id);

        [HttpPost]
        [Route("Edit/{Id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] EditDealerInputModel editDealerInputModel)
        {
            var dealer = await this.dealerService.FindByUserAsync(this.currentUserService.UserId);

            if (id != dealer.Id)
            {
                return this.BadRequest(Result.Failure("You cannot edit this dealer."));
            }

            dealer.Name = editDealerInputModel.Name;
            dealer.PhoneNumber = editDealerInputModel.PhoneNumber;

            await this.dealerService.Save(dealer);

            return this.Ok();
        }
    }
}
