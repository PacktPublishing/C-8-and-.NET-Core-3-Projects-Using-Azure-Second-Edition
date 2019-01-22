using PhotoStorage.WindowsService.AzureClient;
using PhotoStorage.WindowsService.Configuration;
using PhotoStorage.WindowsService.Models;
using System;
using System.ServiceProcess;

namespace PhotoStorage.WindowsService
{
    public class PhotoService : ServiceBase
    {
        private FileMonitor _fileMonitor;
        private AppSettings _appSettings;

        protected override void OnStart(string[] args)
        {
            var configurationService = new ConfigurationService();
            _appSettings = configurationService.Load();

            var cloudStorageClientService = new AzureStorageClientService(_appSettings);
            _fileMonitor = new FileMonitor(_appSettings.MonitorPath, cloudStorageClientService);
        }

        protected override void OnStop()
        {
            _fileMonitor.Dispose();
        }
    }
}
