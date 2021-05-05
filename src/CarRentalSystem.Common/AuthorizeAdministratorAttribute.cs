namespace CarRentalSystem.Common
{
    using Microsoft.AspNetCore.Authorization;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = "Administrator";
    }
}
