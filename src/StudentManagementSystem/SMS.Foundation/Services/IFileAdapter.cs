namespace SMS.Foundation.Services
{
    public interface IFileAdapter
    {
        bool Exists(string path);
    }
}