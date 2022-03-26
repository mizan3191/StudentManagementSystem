using SMS.Membership.Entities.ApplicationUsers;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Autofac;
using System.Threading.Tasks;

namespace SMS.Membership.Seeds
{
    public class SuperAdminDataSeed
    {
        private UserManager<ApplicationUser> _userManager;

        public SuperAdminDataSeed() { }

        public SuperAdminDataSeed(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _userManager = scope.Resolve<UserManager<ApplicationUser>>();
        }

        public async Task SeedUserAsync()
        {
            var modUser = new ApplicationUser
            {
                UserName = "SuperAdmin@gmail.com",
                Email = "SuperAdmin@gmail.com",
                EmailConfirmed = true,
                Name = "Mizanur Rahman"
            };

            IdentityResult result = null;
            var password = "SuperAdmin123@email";

            string? email = "SuperAdmin@gmail.com";

            var user = await _userManager.FindByNameAsync(modUser.UserName);

            if (user == null)
            {
                result = await _userManager.CreateAsync(modUser, password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(modUser, "SuperAdmin");
                    await _userManager.AddClaimAsync(modUser, new Claim("SuperAdmin", "true"));
                }
            }
        }
    }
}