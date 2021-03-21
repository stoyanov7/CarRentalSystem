namespace CarRentalSystem.Identity.Services.Contracts
{
    using CarRentalSystem.Common;
    using CarRentalSystem.Data.Models;
    using System.Threading.Tasks;

    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
    }
}
