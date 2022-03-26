using System.Threading.Tasks;

namespace SMS.Foundation.Services
{
    public interface IReCaptchaService
    {
        Task<bool> IsReCaptchaValid(string token);
    }
}