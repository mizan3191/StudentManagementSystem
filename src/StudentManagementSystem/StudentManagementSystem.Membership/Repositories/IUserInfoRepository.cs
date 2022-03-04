using StudentManagementSystem.Membership.Contexts;
using StudentManagementSystem.Membership.Entities;
using DevSkill.Data;

namespace StudentManagementSystem.Membership.Repositories
{
    public interface IUserInfoRepository : IRepository<Student, int, MembershipDbContext>
    {
    }
}