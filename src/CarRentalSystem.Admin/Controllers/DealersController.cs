namespace CarRentalSystem.Admin.Controllers
{
    using CarRentalSystem.Admin.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class DealersController : AdministrationController
    {
        private readonly IDealerService dealerService;

        public DealersController(IDealerService dealerService) => this.dealerService = dealerService;

        public async Task<IActionResult> Index()
            => this.View(await this.dealerService.GetAllDealersAsync());
    }
}
