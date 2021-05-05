namespace CarRentalSystem.Admin.Models.Dealers
{
    using CarRentalSystem.Common.MappingProfiles;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class DealerViewModel : IMapFrom<DealerDetailsOutputModel>
    {     
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
    }
}
