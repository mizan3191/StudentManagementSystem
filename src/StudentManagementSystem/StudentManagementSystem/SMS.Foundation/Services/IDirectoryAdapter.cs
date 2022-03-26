using System.IO;

namespace SMS.Foundation.Services
{
    public interface IDirectoryAdapter
    {
        bool Exists(string path);
        DirectoryInfo CreateDirectory(string path);
    }
}