using StudentManagementSystem.Membership.Repositories;
using DevSkill.Data;

namespace StudentManagementSystem.Membership.UnitOfWorks
{
    public interface IMembershipUnitOfWork : IUnitOfWork
    {
        public IUserInfoRepository UserInfoRepository { get; }
    }
}