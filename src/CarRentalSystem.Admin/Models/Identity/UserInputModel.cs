namespace CarRentalSystem.Admin.Models.Identity
{
    using CarRentalSystem.Common.MappingProfiles;

    public class UserInputModel : IMapFrom<LoginFormModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
