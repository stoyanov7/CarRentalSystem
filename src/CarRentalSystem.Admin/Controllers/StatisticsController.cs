namespace CarRentalSystem.Admin.Controllers
{
    using CarRentalSystem.Admin.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class StatisticsController : AdministrationController
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statistics) => this.statisticsService = statistics;

        public async Task<IActionResult> Index() => this.View(await this.statisticsService.Full());
    }
}
