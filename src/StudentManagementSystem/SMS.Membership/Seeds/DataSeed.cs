using SMS.Membership.Entities.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Membership.Seeds
{
    public static class DataSeed
    {
        public static Role[] Roles
        {
            get
            {
                return new Role[]
                {
                    new Role { Id = Guid.NewGuid(), Name = "SuperAdmin", NormalizedName = "SUPERADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new Role { Id = Guid.NewGuid(), Name = "CompanyAdmin", NormalizedName = "COMPANYADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new Role { Id = Guid.NewGuid(), Name = "Teacher", NormalizedName = "TEACHER", ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new Role { Id = Guid.NewGuid(), Name = "Student", NormalizedName = "STUDENT", ConcurrencyStamp = Guid.NewGuid().ToString() },
                };
            }
        }
    }
}
