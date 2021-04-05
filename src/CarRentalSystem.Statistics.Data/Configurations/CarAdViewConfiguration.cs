namespace CarRentalSystem.Statistics.Data.Configurations
{
    using CarRentalSystem.Statistics.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CarAdViewConfiguration : IEntityTypeConfiguration<CarAdView>
    {
        public void Configure(EntityTypeBuilder<CarAdView> builder)
        {
            builder.HasKey(v => v.Id);

            builder.HasIndex(v => v.CarAdId);

            builder
                .Property(v => v.UserId)
                .IsRequired();
        }
    }
}
