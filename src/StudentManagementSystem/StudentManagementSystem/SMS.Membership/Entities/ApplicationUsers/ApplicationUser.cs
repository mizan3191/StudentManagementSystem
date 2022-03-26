using Microsoft.AspNetCore.Identity;
using System;

namespace SMS.Membership.Entities.ApplicationUsers
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int MobileNumber { get; set; }
        public string Photo { get; set; }
    }
}