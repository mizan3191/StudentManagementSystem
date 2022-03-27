using System;

namespace SMS.Foundation.Services
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