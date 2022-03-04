using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Foundation.Services
{
    public class InvitationCodeGeneratorService : IInvitationCodeGeneratorService
    {
        public string GetInvitationCode()
        {
            var code = Guid.NewGuid().ToString();
            var invitationCode = code.Replace("-", "");

            return invitationCode;
        }
    }
}