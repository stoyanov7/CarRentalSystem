namespace CarRentalSystem.Statistics.Service.Contracts
{
    using System.Threading.Tasks;

    public interface IStatisticsService
    {
        Task<TModel> Full<TModel>();

        Task IncrementCarAd();
    }
}
