using DevSkill.Data;
using System;

namespace StudentManagementSystem.Membership.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
    }
}