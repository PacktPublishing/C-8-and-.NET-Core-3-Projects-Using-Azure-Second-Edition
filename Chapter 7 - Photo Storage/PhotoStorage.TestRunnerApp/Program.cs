using PhotoStorage.WindowsService;
using PhotoStorage.WindowsService.AzureClient;
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
            var cloudStorageClientService = new AzureStorageClientService();

            using (var fileMonitor = new FileMonitor(@"c:\tmp", cloudStorageClientService))
            {
                for (; ; )
                {
                    
                }
            }
        }
    }
}
