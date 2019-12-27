using PhotoStorage.Helpers.FileHelper;
using System;
using System.IO;
using System.IO.Enumeration;
using System.Linq;

namespace PhotoStorage.WindowsService.Helpers
{
    public class FileDiscoverer : IFileDiscoverer
    {
        private readonly ILogger _logger;

        public FileDiscoverer(ILogger logger)
        {
            _logger = logger;
        }

        public void DiscoverFiles(string directory, Action<string> action)
        {
            var enumerationOptions = new EnumerationOptions()
            {
                RecurseSubdirectories = false,
                AttributesToSkip = FileAttributes.Directory 
                | FileAttributes.Device | FileAttributes.Hidden                
            };

            var files = new FileSystemEnumerable<FileInfo>(directory,
                 (ref FileSystemEntry entry) => (FileInfo)entry.ToFileSystemInfo(),
                enumerationOptions)
            {
                ShouldIncludePredicate = (ref FileSystemEntry entry) => 
                    FileHelper.IsImage(entry.FileName.ToString())
            };

            _logger.Log($"Found {files.Count()} files");

            foreach (var file in files)
            {
                _logger.Log($"Uploading {file.FullName}");
                action.Invoke(file.FullName);
            }
        }
    }
}
