namespace CarRentalSystem.Common.Service.Contracts
{
    using CarRentalSystem.Common.Data;
    using System.Threading.Tasks;

    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task MarkMessageAsPublished(int id);

        Task Save(TEntity entity, params Message[] messages);
    }
}
