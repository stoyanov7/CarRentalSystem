namespace CarRentalSystem.Admin.Controllers
{
    using CarRentalSystem.Admin.Models;
    using CarRentalSystem.Common.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger) => this.logger = logger;

        public IActionResult Index()
        {            
            if (this.User.IsAdministrator())
            {
                return this.RedirectToAction(nameof(StatisticsController.Index), "Statistics");
            }

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}
