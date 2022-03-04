namespace StudentManagementSystem.Foundation.Services
{
    public interface IFileAdapter
    {
        bool Exists(string path);
    }
}