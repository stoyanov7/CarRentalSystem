namespace CarRentalSystem.Dealers.Gateway.Services
{
    using CarRentalSystem.Dealers.Gateway.Models;
    using Refit;
    using System.Threading.Tasks;

    public interface ICarAdService
    {
        [Get("/CarAds/Mine")]
        Task<MineCarAdsOutputModel> Mine();
    }
}
