using StudentManagementSystem.Membership.Contexts;
using StudentManagementSystem.Membership.Entities;
using DevSkill.Data;

namespace StudentManagementSystem.Membership.Repositories
{
    public class UserInfoRepository : Repository<Student, int, MembershipDbContext>, IUserInfoRepository
    {
        public UserInfoRepository(IMembershipDbContext dbContext)
            :base((MembershipDbContext)dbContext)
        {

        }
    }
}