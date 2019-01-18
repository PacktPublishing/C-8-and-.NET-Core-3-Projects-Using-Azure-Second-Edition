using PhotoStorage.WindowsService.AzureClient;
using System;
using System.IO;

namespace PhotoStorage.WindowsService
{
    public class FileMonitor : IDisposable
    {        
        private FileSystemWatcher _fileSystemWatcher;
        private ICloudStorageClientService _cloudStorageClientService;

        public FileMonitor(string path, ICloudStorageClientService cloudStorageClientService)
        {
            _cloudStorageClientService = cloudStorageClientService;

            _fileSystemWatcher = new FileSystemWatcher(path);
            _fileSystemWatcher.Filter = "*.*";
            _fileSystemWatcher.EnableRaisingEvents = true;

            _fileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
            _fileSystemWatcher.Created += new FileSystemEventHandler(OnCreated);            
            _fileSystemWatcher.Renamed += new RenamedEventHandler(OnRenamed);
        }

        private async void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (await _cloudStorageClientService.FileExists(e.Name))
            {
                await _cloudStorageClientService.RenameFile(e.Name, e.OldName);
            }
            else
            {
                await _cloudStorageClientService.UploadFile(e.FullPath);
            }
        }

        private async void OnCreated(object sender, FileSystemEventArgs e)
        {
            await _cloudStorageClientService.UploadFile(e.FullPath);
        }

        private async void OnChanged(object sender, FileSystemEventArgs e)
        {
            await _cloudStorageClientService.UploadFile(e.FullPath);
        }

        public void Dispose()
        {
            _fileSystemWatcher.Dispose();
        }
    }
}