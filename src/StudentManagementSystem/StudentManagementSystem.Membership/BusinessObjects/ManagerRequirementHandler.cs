﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace StudentManagementSystem.Membership.BusinessObjects
{
    public class ManagerRequirementHandler : AuthorizationHandler<ManagerRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ManagerRequirement requirement)
        {
            var claim = context.User.FindFirst("Manager");

            if(claim != null && bool.Parse(claim.Value))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}