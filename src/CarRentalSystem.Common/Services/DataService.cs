namespace CarRentalSystem.Common.Service
{
    using CarRentalSystem.Common.Data;
    using CarRentalSystem.Common.Service.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class DataService<TEntity> : IDataService<TEntity>
        where TEntity : class
    {
        protected DataService(DbContext context) => this.Context = context;

        protected DbContext Context { get; }

        protected IQueryable<TEntity> All() => this.Context.Set<TEntity>();

        public async Task MarkMessageAsPublished(int id)
        {
            var message = await this.Context.FindAsync<Message>(id);
            message.MarkAsPublished();

            await this.Context.SaveChangesAsync();
        }

        public async Task Save(TEntity entity, params Message[] messages)
        {
            foreach (var message in messages)
            {
                this.Context.Add(message);
            }

            this.Context.Update(entity);

            await this.Context.SaveChangesAsync();
        }        
    }
}
