namespace CarRentalSystem.Statistics.API.Controllers
{
    using CarRentalSystem.Common.Controllers;
    using CarRentalSystem.Statistics.API.Models;
    using CarRentalSystem.Statistics.Service.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics) => this.statistics = statistics;

        [HttpGet]
        [Route(nameof(Full))]
        public async Task<StatisticsOutputModel> Full() => await this.statistics.Full<StatisticsOutputModel>();
    }
}
