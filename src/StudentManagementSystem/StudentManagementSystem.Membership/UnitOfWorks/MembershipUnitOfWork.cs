using StudentManagementSystem.Membership.Contexts;
using StudentManagementSystem.Membership.Repositories;
using StudentManagementSystem.Membership.UnitOfWorks;
using DevSkill.Data;

namespace StudentManagementSystem.Membership.UnitOfWorks
{
    public class MembershipUnitOfWork : UnitOfWork, IMembershipUnitOfWork
    {
        public IUserInfoRepository UserInfoRepository { get; private set; }

        public MembershipUnitOfWork(IMembershipDbContext dbContext, 
            IUserInfoRepository userInfoRepository)
            : base((MembershipDbContext)dbContext)
        {
            UserInfoRepository = userInfoRepository;
        }
    }
}