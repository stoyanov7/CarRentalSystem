namespace CarRentalSystem.Dealers.Service.Contracts
{
    using CarRentalSystem.Common.Service;
    using CarRentalSystem.Dealers.Data.Models;
    using System.Threading.Tasks;

    public interface IDealerService : IDataService<Dealer>
    {
        Task<TModel> GetDetailsAsync<TModel>(int id);

        Task<Dealer> FindByUserAsync(string userId);

        Task<bool> IsDealerAsync(string userId);

        Task<int> GetDealerIdByUserIdAsync(string userId);

        Task<bool> HasCarAd(int dealerId, int carAdId);
    }
}
