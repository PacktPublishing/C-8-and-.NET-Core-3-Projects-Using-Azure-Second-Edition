using PhotoStorage.WindowsService.AzureClient;
using PhotoStorage.WindowsService.Configuration;
using PhotoStorage.WindowsService.Models;
using System;
using System.ServiceProcess;

namespace PhotoStorage.WindowsService
{
    public class PhotoService : ServiceBase
    {
        private readonly string _path;
        private FileMonitor _fileMonitor;
        private AppSettings _appSettings;

        public PhotoService(string path)
        {
            ServiceName = "PhotoService";
            AutoLog = true;
            _path = path;
        }

        protected override void OnStart(string[] args)
        {            
            var configurationService = new ConfigurationService();
            _appSettings = configurationService.Load(_path);

            var cloudStorageClientService = new AzureStorageClientService(_appSettings);
            _fileMonitor = new FileMonitor(_appSettings.MonitorPath, cloudStorageClientService);
        }

        protected override void OnStop()
        {
            _fileMonitor.Dispose();
        }
    }
}
