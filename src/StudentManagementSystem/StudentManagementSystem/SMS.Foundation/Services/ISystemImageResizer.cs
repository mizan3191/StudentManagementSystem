using System.IO;
using System.Threading.Tasks;

namespace SMS.Foundation.Services
{
    public interface ISystemImageResizer
    {
        Task<FileInfo> ProfileImageResizeAsync(FileInfo temporaryImageFile);
    }
}