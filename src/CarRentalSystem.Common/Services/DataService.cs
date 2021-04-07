namespace CarRentalSystem.Common.Service
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class DataService<TEntity> : IDataService<TEntity>
        where TEntity : class
    {
        protected DataService(DbContext context) => this.Context = context;

        protected DbContext Context { get; }

        protected IQueryable<TEntity> All() => this.Context.Set<TEntity>();

        public async Task Save(TEntity entity)
        {
            this.Context.Update(entity);

            await this.Context.SaveChangesAsync();
        }
    }
}
