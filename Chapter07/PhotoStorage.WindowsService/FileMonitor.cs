using PhotoStorage.Helpers.FileHelper;
using PhotoStorage.WindowsService.AzureClient;
using PhotoStorage.WindowsService.Helpers;
using System;
using System.IO;


namespace PhotoStorage.WindowsService
{
    public class FileMonitor : IDisposable
    {        
        private FileSystemWatcher _fileSystemWatcher;
        private ICloudStorageClientService _cloudStorageClientService;
        private ILogger _logger;

        public FileMonitor(string path, ICloudStorageClientService cloudStorageClientService, ILogger logger)
        {
            _cloudStorageClientService = cloudStorageClientService;
            _logger = logger;
            _fileSystemWatcher = new FileSystemWatcher(path);
            _fileSystemWatcher.Filter = "*.*";
            _fileSystemWatcher.EnableRaisingEvents = true;

            _fileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
            _fileSystemWatcher.Created += new FileSystemEventHandler(OnCreated);            
            _fileSystemWatcher.Renamed += new RenamedEventHandler(OnRenamed);            
        }

        private async void OnRenamed(object sender, RenamedEventArgs e)
        {
            _logger.Log($"File Renamed: {e.Name}");

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
            if (!FileHelper.IsImage(e.Name)) return;

            _logger.Log($"File Created: {e.Name}");

            await _cloudStorageClientService.UploadFile(e.FullPath);
        }

        private async void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!FileHelper.IsImage(e.Name)) return;

            _logger.Log($"File Changed: {e.Name}");

            await _cloudStorageClientService.UploadFile(e.FullPath);
        }

        public void Dispose()
        {
            _fileSystemWatcher.Dispose();
        }
    }
}