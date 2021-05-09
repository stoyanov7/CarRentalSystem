namespace CarRentalSystem.Admin.Services
{
    using CarRentalSystem.Admin.Models;
    using Refit;
    using System.Threading.Tasks;

    public interface IStatisticsService
    {
        [Get("/Statistics/Full")]
        Task<StatisticsOutputModel> Full();
    }
}
