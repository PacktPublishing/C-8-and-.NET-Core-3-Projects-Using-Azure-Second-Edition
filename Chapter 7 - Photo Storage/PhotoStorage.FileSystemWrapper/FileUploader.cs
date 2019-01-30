using PhotoStorage.Helpers.FileHelper;
using System;
using System.IO;
using System.IO.Enumeration;

namespace PhotoStorage.FileSystemWrapper
{
    public class FileUploader
    {
        public void UploadFiles(string directory)
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

            foreach (var file in files)
            {

            }
        }
    }
}
