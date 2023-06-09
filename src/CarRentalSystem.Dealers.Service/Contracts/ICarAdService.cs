﻿namespace CarRentalSystem.Dealers.Service.Contracts
{
    using CarRentalSystem.Common.Service.Contracts;
    using CarRentalSystem.Dealers.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarAdService : IDataService<CarAd>
    {
        Task<TModel> GetDetails<TModel>(int id);

        Task<CarAd> FindByIdAsync(int id);

        Task<bool> Delete(int id);

        Task<IEnumerable<TModel>> GetListings<TModel>(ICarAdsDto query);

        Task<int> Total(ICarAdsDto query);

        Task<IEnumerable<TModel>> Mine<TModel>(int dealerId, ICarAdsDto query);
    }
}
