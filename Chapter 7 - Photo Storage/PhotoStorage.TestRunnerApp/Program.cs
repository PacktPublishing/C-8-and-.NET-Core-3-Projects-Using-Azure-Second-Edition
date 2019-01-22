using PhotoStorage.WindowsService;
using PhotoStorage.WindowsService.AzureClient;
using PhotoStorage.WindowsService.Configuration;
using System;
using System.Threading.Tasks;

namespace PhotoStorage.TestRunnerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFileMonitorNewFile();
            
        }

        static void TestFileMonitorNewFile()
        {
            var configurationService = new ConfigurationService();
            var appSettings = configurationService.Load();

            var cloudStorageClientService = new AzureStorageClientService(appSettings);

            using (var fileMonitor = new FileMonitor(appSettings.MonitorPath, cloudStorageClientService))
            {
                for (; ; )
                {
                    
                }
            }
        }
    }
}
