namespace CarRentalSystem.Common.Data
{
    using CarRentalSystem.Common.Data.Configurations;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public abstract class MessageContext : DbContext
    {
        protected MessageContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected abstract Assembly ConfigurationsAssembly { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfigurationsFromAssembly(this.ConfigurationsAssembly);

            base.OnModelCreating(builder);
        }
    }
}
