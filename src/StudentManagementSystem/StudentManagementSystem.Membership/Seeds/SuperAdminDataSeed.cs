using StudentManagementSystem.Membership.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace StudentManagementSystem.Membership.Seeds
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
                UserName = "SuperAdmin@email.com",
                Email = "SuperAdmin@email.com",
                EmailConfirmed = true
            };

            IdentityResult result = null;
            var password = "SuperAdmin@email";

            if (await _userManager.FindByEmailAsync(modUser.Email) == null)
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