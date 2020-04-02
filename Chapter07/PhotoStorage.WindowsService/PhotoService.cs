using PhotoStorage.WindowsService.AzureClient;
using PhotoStorage.WindowsService.Configuration;
using PhotoStorage.WindowsService.Helpers;
using PhotoStorage.WindowsService.Models;
using System;
using System.ServiceProcess;

namespace PhotoStorage.WindowsService
{
    public class PhotoService : ServiceBase
    {
        private readonly string _path;
        private readonly ILogger _logger;
        private readonly IFileDiscoverer _fileDiscoverer;
        private FileMonitor _fileMonitor;
        private AppSettings _appSettings;

        public PhotoService(string path, ILogger logger, IFileDiscoverer fileDiscoverer)
        {
            ServiceName = "PhotoService";
            AutoLog = true;
            _path = path;
            _logger = logger;
            _fileDiscoverer = fileDiscoverer;
        }

        protected override void OnStart(string[] args)
        {
            _logger.Log("PhotoService Starting");

            var configurationService = new ConfigurationService();
            _appSettings = configurationService.Load(_path);

            _logger.Log($"PhotoService Monitoring: {_appSettings.MonitorPath}");
            _logger.Log($"PhotoService Cloud Storage Connection: {_appSettings.ConnectionString}");

            var cloudStorageClientService = new AzureStorageClientService(_appSettings);

            _fileDiscoverer.DiscoverFiles(_appSettings.MonitorPath, (file) => cloudStorageClientService.UploadFile(file));
            _fileMonitor = new FileMonitor(_appSettings.MonitorPath, cloudStorageClientService, _logger);
        }

        protected override void OnStop()
        {
            _logger.Log("PhotoService Stopping");

            _fileMonitor.Dispose();
        }
    }
}
