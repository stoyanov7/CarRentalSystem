namespace CarRentalSystem.Admin.Models.Dealers
{
    using CarRentalSystem.Common.MappingProfiles;

    public class DealerInputModel : IMapFrom<DealerViewModel>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
