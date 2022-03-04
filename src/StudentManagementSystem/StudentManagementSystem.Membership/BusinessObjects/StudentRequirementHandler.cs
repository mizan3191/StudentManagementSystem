using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Membership.BusinessObjects
{
    public class StudentRequirementHandler : AuthorizationHandler<StudentRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            StudentRequirement requirement)
        {
            var claim = context.User.FindFirst("User");

            if(claim != null && bool.Parse(claim.Value))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}