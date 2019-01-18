using PhotoStorage.WindowsService.AzureClient;
using System;
using System.ServiceProcess;

namespace PhotoStorage.WindowsService
{
    public class PhotoService : ServiceBase
    {
        private FileMonitor _fileMonitor;

        protected override void OnStart(string[] args)
        {
            var cloudStorageClientService = new AzureStorageClientService();
            _fileMonitor = new FileMonitor(@"c:\tmp", cloudStorageClientService);
        }

        protected override void OnStop()
        {
            _fileMonitor.Dispose();
        }
    }
}
