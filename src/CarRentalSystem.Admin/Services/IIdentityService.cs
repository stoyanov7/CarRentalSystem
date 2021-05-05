namespace CarRentalSystem.Admin.Services
{
    using CarRentalSystem.Admin.Models.Identity;
    using Refit;
    using System.Threading.Tasks;

    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}
