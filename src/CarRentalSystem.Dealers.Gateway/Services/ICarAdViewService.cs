namespace CarRentalSystem.Dealers.Gateway.Services
{
    using CarRentalSystem.Dealers.Gateway.Models;
    using Refit;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarAdViewService
    {
        [Get("/CarAdViews")]
        Task<IEnumerable<CarAdViewOutputModel>> TotalViews([Query(CollectionFormat.Multi)] IEnumerable<int> ids);
    }
}
