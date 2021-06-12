namespace CarRentalSystem.Schedule.Data.Configurations
{
    using CarRentalSystem.Schedule.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.License)
                .IsRequired();

            builder
                .Property(c => c.UserId)
                .IsRequired();
        }
    }
}
