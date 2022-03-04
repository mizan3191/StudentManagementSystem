using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Membership.BusinessObjects
{
    public class TeacherRequirement : IAuthorizationRequirement
    {
        public TeacherRequirement()
        {

        }
    }
}
