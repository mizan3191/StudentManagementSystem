using StudentManagementSystem.Membership.BusinessObjects;
using StudentManagementSystem.Membership.UnitOfWorks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Membership.Services
{
    public class UserInfoService : IUserInfoService
    {
        private IMembershipUnitOfWork _unitOfWork;
        
        public UserInfoService(IMembershipUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
    }
}