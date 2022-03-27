using System.ComponentModel.DataAnnotations;

namespace SMS.Web.Models.AccountModel
{
    public class ForgotPasswordModel : BaseModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}