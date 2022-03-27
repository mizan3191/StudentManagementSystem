using Microsoft.Extensions.Options;
using SMS.Foundation.Utilities.Settings;
using System;
using System.IO;

namespace SMS.Foundation.Services
{
    public class PathService : IPathService
    {
        public string DefaultFileStoragePath { get; private set; }
        public string ProfileImagePath { get; private set; }
        public string DefaultProfileImagePath { get; private set; }
        public string DefaultProfileImage { get; private set; }
        public string TempFolder { get; private set; }

        public PathService(IOptions<PathSettings> settings, IOptions<DefaultSiteSettings> defaultSiteSettings)
        {
            var paths = settings.Value;
            var defaultSitePaths = defaultSiteSettings.Value;
            DefaultFileStoragePath = paths.DefaultFileStoragePath;
            ProfileImagePath = paths.ProfileImagePath;
            DefaultProfileImagePath = paths.DefaultProfileImagePath;
            TempFolder = paths.TempFolder;
            DefaultProfileImage = defaultSitePaths.DefaultProfileImage;
        }

        public string AttachPathWithDefaultProfileImage(string defaultProfileImageName)
        {
            if (string.IsNullOrWhiteSpace(defaultProfileImageName))
                throw new InvalidOperationException("Default Profile image name must be provided to attach path with Default Profile image!");

            return Path.Combine(DefaultProfileImagePath, DefaultProfileImage);
        }

        public string AttachPathWithFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new InvalidOperationException("File name must be provided to attach path with file!");

            return Path.Combine(DefaultFileStoragePath, fileName);
        }

        public string AttachPathWithProfileImage(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return null;

            return Path.Combine(ProfileImagePath, imageName);
        }
    }
}
