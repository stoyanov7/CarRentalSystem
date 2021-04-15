namespace CarRentalSystem.Admin.Controllers
{
    using AutoMapper;
    using CarRentalSystem.Admin.Models.Identity;
    using CarRentalSystem.Admin.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class IdentityController : AdministrationController
    {
        private readonly IIdentityService identityService;
        private readonly IMapper mapper;

        public IdentityController(IIdentityService identityService, IMapper mapper)
        {
            this.identityService = identityService;
            this.mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model)
            => await this.Handle(
                async () =>
                {
                    var result = await this.identityService.Login(this.mapper.Map<UserInputModel>(model));
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        MaxAge = TimeSpan.FromDays(1)
                    };

                    this.Response.Cookies.Append("Authentication", result.Token, cookieOptions);
                },
                success: this.RedirectToAction(nameof(StatisticsController.Index), "Statistics"),
                failure: this.View("../Home/Index", model));
    }
}
