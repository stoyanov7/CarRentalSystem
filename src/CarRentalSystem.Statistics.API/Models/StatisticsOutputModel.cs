namespace CarRentalSystem.Statistics.API.Models
{
    using CarRentalSystem.Common.MappingProfiles;
    using CarRentalSystem.Statistics.Data.Models;

    public class StatisticsOutputModel : IMapFrom<Statistics>
    {
        public long TotalCarAds { get; set; }

        public long TotalRentedCars { get; set; }
    }
}
