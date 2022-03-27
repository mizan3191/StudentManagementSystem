using Microsoft.AspNetCore.Identity;
using System;

namespace SMS.Membership.Entities.ApplicationUsers
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
        public string Photo { get; set; }
    }
}