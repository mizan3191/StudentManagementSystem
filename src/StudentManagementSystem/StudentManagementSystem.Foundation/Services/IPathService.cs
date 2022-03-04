namespace StudentManagementSystem.Foundation.Services
{
    public interface IPathService
    {
        string DefaultFileStoragePath { get; }
        string ProfileImagePath { get; }
        string DefaultProfileImagePath { get; }
        string DefaultProfileImage { get; }
        string TempFolder { get; }
        string AttachPathWithProfileImage(string imageName);
        string AttachPathWithFile(string fileName);
        string AttachPathWithDefaultProfileImage(string defaultProfileImageName);
    }
}