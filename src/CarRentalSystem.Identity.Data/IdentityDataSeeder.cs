namespace CarRentalSystem.Identity.Data
{
    using CarRentalSystem.Common.Services.Contracts;
    using CarRentalSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Threading.Tasks;

    public class IdentityDataSeeder : IDataSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityDataSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedData()
        {
            if (this.roleManager.Roles.Any())
            {
                return;
            }

            Task
                .Run(async () =>
                {
                    await this.roleManager.CreateAsync(new IdentityRole("Administrator"));

                    var adminUser = new User
                    {
                        UserName = "admin@admin.com",
                        Email = "admin@admin.com",
                        SecurityStamp = "RandomSecurityStamp"
                    };

                    await userManager.CreateAsync(adminUser, "adminpass123");
                    await userManager.AddToRoleAsync(adminUser, "Administrator");
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
