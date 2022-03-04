using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Membership.Entities
{
    public class Teacher : IEntity<int>
    {
        public int Id { get; set; }
        public string InvitationCode { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
