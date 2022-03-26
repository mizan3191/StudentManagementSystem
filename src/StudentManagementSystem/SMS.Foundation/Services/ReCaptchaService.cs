using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SMS.Foundation.Utilities.ReCaptcha;
using SMS.Foundation.Utilities.Settings;
using System.Net.Http;
using System.Threading.Tasks;

namespace SMS.Foundation.Services
{
    public class ReCaptchaService : IReCaptchaService
    {
        private ReCaptchaKey _reCaptchKey;

        public ReCaptchaService(IOptions<ReCaptchaKey> reCaptchKey)
        {
            _reCaptchKey = reCaptchKey.Value;
        }

        public virtual async Task<bool> IsReCaptchaValid(string token)
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?secret={_reCaptchKey.ReCAPTCHASecretKey}&response={token}");
            var capResponse = JsonConvert.DeserializeObject<ReCapcthaResponse>(response);

            if (!capResponse.Success && capResponse.Score <= 0.5)
            {
                return false;
            }

            return true;
        }
    }
}