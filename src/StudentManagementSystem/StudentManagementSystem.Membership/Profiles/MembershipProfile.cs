using AutoMapper;
using EO = StudentManagementSystem.Membership.Entities;
using BO = StudentManagementSystem.Membership.BusinessObjects;

namespace StudentManagementSystem.Membership.Profiles
{
    public class MembershipProfile : Profile
    {
        public MembershipProfile()
        {
            CreateMap<EO.Student, BO.Student>().ReverseMap();
        }
    }
}