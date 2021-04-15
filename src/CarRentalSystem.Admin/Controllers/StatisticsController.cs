namespace CarRentalSystem.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class StatisticsController : Controller
    {
        public IActionResult Index() => this.View();
    }
}
