using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Membership.BusinessObjects
{
    public class StudentRequirement : IAuthorizationRequirement
    {
        public StudentRequirement()
        {

        }
    }
}
