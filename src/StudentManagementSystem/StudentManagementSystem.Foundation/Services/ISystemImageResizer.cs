namespace StudentManagementSystem.Foundation.Services
{
    public interface ISystemImageResizer
    {
        Task<FileInfo> ProfileImageResizeAsync(FileInfo temporaryImageFile);
    }
}