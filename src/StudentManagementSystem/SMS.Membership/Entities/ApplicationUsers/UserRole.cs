using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SMS.Membership.Entities.ApplicationUsers
{
    public class UserRole
        : IdentityUserRole<Guid>
    {
       
    }
}
