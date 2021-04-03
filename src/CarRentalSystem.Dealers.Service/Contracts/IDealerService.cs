namespace CarRentalSystem.Dealers.Service.Contracts
{
    using CarRentalSystem.Dealers.Data.Models;
    using System.Threading.Tasks;

    public interface IDealerService : IDataService<Dealer>
    {
        Task<TModel> GetDetailsAsync<TModel>(int id);

        Task<Dealer> FindByUserAsync(string userId);
    }
}
