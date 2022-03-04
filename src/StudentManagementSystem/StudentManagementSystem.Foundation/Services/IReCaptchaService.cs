namespace StudentManagementSystem.Foundation.Services
{
    public interface IReCaptchaService
    {
        Task<bool> IsReCaptchaValid(string token);
    }
}