namespace CarRentalSystem.Dealers.API.Controllers
{
    using CarRentalSystem.Common;
    using CarRentalSystem.Common.Controllers;
    using CarRentalSystem.Common.Service.Contracts;
    using CarRentalSystem.Dealers.API.Models.Dealers.InputModels;
    using CarRentalSystem.Dealers.API.Models.Dealers.OutputModels;
    using CarRentalSystem.Dealers.Data.Models;
    using CarRentalSystem.Dealers.Service.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
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
        public async Task<IActionResult> Create(CreateDealerInputModel createDealerInputModel)
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

        [HttpPost]
        [Route(nameof(Edit) + PathSeparator + Id)]
        public async Task<IActionResult> Edit(int id, EditDealerInputModel editDealerInputModel)
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

        [HttpGet]
        [Route(nameof(Details) + PathSeparator + Id)]
        public async Task<ActionResult<DealerDetailsOutputModel>> Details(int id)
            => await this.dealerService.GetDetailsAsync<DealerDetailsOutputModel>(id);

        [HttpGet]
        [Authorize]
        [Route(nameof(GetDealerId))]
        public async Task<ActionResult<int>> GetDealerId()
        {
            var userId = this.currentUserService.UserId;
            var isUserDealer = await this.dealerService.IsDealerAsync(userId);

            if (!isUserDealer)
            {
                return this.BadRequest("This user is not a dealer.");
            }

            return await this.dealerService.GetDealerIdByUserIdAsync(this.currentUserService.UserId);
        }

        [HttpGet]
        [AuthorizeAdministrator]
        [Route(nameof(GetAllDealers))]
        public async Task<IEnumerable<DealerDetailsOutputModel>> GetAllDealers()
            => await this.dealerService.GetAllDealersAsync<DealerDetailsOutputModel>();
    }
}
