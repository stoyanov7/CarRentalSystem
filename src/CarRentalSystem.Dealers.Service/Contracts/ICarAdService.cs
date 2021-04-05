namespace CarRentalSystem.Dealers.Service.Contracts
{
    using CarRentalSystem.Dealers.Data.Models;
    using System.Threading.Tasks;

    public interface ICarAdService : IDataService<CarAd>
    {
        Task<TModel> GetDetails<TModel>(int id);

        Task<CarAd> FindByIdAsync(int id);

        Task<bool> Delete(int id);
    }
}
