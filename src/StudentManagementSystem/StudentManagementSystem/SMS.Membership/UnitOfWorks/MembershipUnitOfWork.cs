using SMS.Membership.Contexts;
using SMS.Membership.UnitOfWorks;
using DevSkill.Data;

namespace SMS.Membership.UnitOfWorks
{
    public class MembershipUnitOfWork : UnitOfWork, IMembershipUnitOfWork
    {
        public MembershipUnitOfWork(IMembershipDbContext dbContext)
            : base((MembershipDbContext)dbContext)
        {
        }
    }
}