namespace CarRentalSystem.Statistics.API.Models
{
    using CarRentalSystem.Common.MappingProfiles;
    using CarRentalSystem.Statistics.Data.Models;

    public class StatisticsOutputModel : IMapFrom<Statistics>
    {
        public int TotalCarAds { get; set; }

        public int TotalRentedCars { get; set; }
    }
}
