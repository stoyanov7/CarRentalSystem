namespace CarRentalSystem.Identity.API.Controllers
{
    using System.Threading.Tasks;
    using CarRentalSystem.Common.Controllers;
    using CarRentalSystem.Common.Service.Contracts;
    using CarRentalSystem.Data.Models;
    using CarRentalSystem.Identity.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;
        private readonly ICurrentUserService currentUser;

        public IdentityController(IIdentityService identity, ICurrentUserService currentUser)
        {
            this.identity = identity;
            this.currentUser = currentUser;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<UserOutputModel>> Register(UserInputModel input)
        {
            var result = await this.identity.Register(input);

            if (!result.Succeeded)
            {
                return this.BadRequest(result.Errors);
            }

            return await this.Login(input);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<UserOutputModel>> Login(UserInputModel input)
        {
            var result = await this.identity.Login(input);

            if (!result.Succeeded)
            {
                return this.BadRequest(result.Errors);
            }

            return new UserOutputModel(result.Data.Token);
        }

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordInputModel input)
            => await this.identity.ChangePassword(this.currentUser.UserId, new ChangePasswordInputModel
            {
                CurrentPassword = input.CurrentPassword,
                NewPassword = input.NewPassword
            });
    }
}