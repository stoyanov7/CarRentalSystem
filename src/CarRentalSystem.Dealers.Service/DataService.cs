namespace CarRentalSystem.Dealers.Service.Contracts
{
    using CarRentalSystem.Dealers.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class DataService<TEntity> : IDataService<TEntity>
        where TEntity : class
    {
        protected DataService(DealersContext dealersContext) => this.DealersContext = dealersContext;

        protected DealersContext DealersContext { get; }

        protected IQueryable<TEntity> All() => this.DealersContext.Set<TEntity>();

        public async Task Save(TEntity entity)
        {
            this.DealersContext.Update(entity);

            await this.DealersContext.SaveChangesAsync();
        }
    }
}
