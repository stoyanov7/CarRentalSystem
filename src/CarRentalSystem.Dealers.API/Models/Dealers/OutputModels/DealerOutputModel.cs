namespace CarRentalSystem.Dealers.API.Models.Dealers.OutputModels
{
    using CarRentalSystem.Common.MappingProfiles;
    using CarRentalSystem.Dealers.Data.Models;

    public class DealerOutputModel : IMapFrom<Dealer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
