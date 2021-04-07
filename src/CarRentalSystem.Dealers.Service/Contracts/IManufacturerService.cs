namespace CarRentalSystem.Dealers.Service.Contracts
{
    using CarRentalSystem.Common.Service;
    using CarRentalSystem.Dealers.Data.Models;
    using System.Threading.Tasks;

    public interface IManufacturerService : IDataService<Manufacturer>
    {
        Task<TModel> FindByNameAsync<TModel>(string name);
    }
}
