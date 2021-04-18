namespace CarRentalSystem.Admin.Controllers
{
    using AutoMapper;
    using CarRentalSystem.Admin.Models.Dealers;
    using CarRentalSystem.Admin.Services;
    using Microsoft.AspNetCore.Mvc;
    using Refit;
    using System.Threading.Tasks;

    public class DealersController : AdministrationController
    {
        private readonly IDealerService dealerService;
        private readonly IMapper mapper;

        public DealersController(IDealerService dealerService, IMapper mapper)
        {
            this.dealerService = dealerService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
            => this.View(await this.dealerService.GetAllDealersAsync());

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dealerDetails = await this.dealerService.GetDetailsAsync(id);
            var model = this.mapper.Map<DealerViewModel>(dealerDetails);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DealerViewModel model)
            => await this.Handle(async () =>
            {
                await this.dealerService.Edit(id, this.mapper.Map<DealerInputModel>(model));
            },
            success: this.RedirectToAction(nameof(Index)),
            failure: this.View(model));
    }
}
