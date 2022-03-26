using Microsoft.AspNetCore.Http;

namespace SMS.Foundation.Services
{
    public interface IFileStoreUtility
    {
        public (string path, string name) GetFile(IFormFile file);
    }
}
