namespace CarRentalSystem.Schedule.Data.Configurations
{
    using CarRentalSystem.Schedule.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class RentedCarConfiguration : IEntityTypeConfiguration<RentedCar>
    {
        public void Configure(EntityTypeBuilder<RentedCar> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Information)
                .IsRequired();
        }
    }
}
