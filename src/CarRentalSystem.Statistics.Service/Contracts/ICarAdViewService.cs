namespace CarRentalSystem.Statistics.Service.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarAdViewService
    {
        Task<int> GetTotalViews(int carAdId);

        Task<IEnumerable<TModel>> GetTotalViews<TModel>(IEnumerable<int> ids);
    }
}
