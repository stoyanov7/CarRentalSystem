﻿namespace CarRentalSystem.Dealers.Service.Contracts
{
    using System.Threading.Tasks;

    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task Save(TEntity entity);
    }
}
