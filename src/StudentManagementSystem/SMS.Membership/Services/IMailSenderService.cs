using SMS.Membership.Entities.ApplicationUsers;
using System.Threading.Tasks;

namespace SMS.Membership.Services
{
    public interface IMailSenderService
    {
        Task SendEmailConfirmationMailAsync(ApplicationUser user, string verificationCode);
    }
}