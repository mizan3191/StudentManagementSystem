using DevSkill.Http.Emails.Services;
using SMS.Membership.Entities.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SMS.Membership.Services
{
    public class MailSenderService : IMailSenderService
    {
        private readonly IQueuedEmailService _queuedEmailService;
        private readonly IUrlService _urlService;
        private const string confirmationEmailSubject = "Confirmation Email";

        public MailSenderService(IQueuedEmailService queuedEmailService,
            IUrlService urlService)
        {
            _queuedEmailService = queuedEmailService;
            _urlService = urlService;
        }

        public void Dispose()
        {

        }
        public async Task SendEmailConfirmationMailAsync(ApplicationUser user, string verificationCode)
        {
            var verificationLink = _urlService.GenerateAbsoluteUrl("Account", "ConfirmEmail",
                new { username = user.UserName, code = verificationCode, area = "" });

            var emailBody = $"Please click the link to confirm your email {verificationLink}" ;

            await _queuedEmailService.SendSingleEmailAsync(user.UserName, user.UserName, confirmationEmailSubject, emailBody);
        }

    }
}
