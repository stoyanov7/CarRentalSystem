namespace CarRentalSystem.Dealers.Service.Contracts
{
    using CarRentalSystem.Dealers.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService : IDataService<Category>
    {
        Task<TModel> FindByIdAsync<TModel>(int categoryId);

        Task<IEnumerable<TModel>> GetAll<TModel>();
    }
}
