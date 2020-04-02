using PhotoStorage.WindowsService.Helpers;
using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace PhotoStorage.WindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];

            var logger = new FileLogger(path);
            var fileDiscoverer = new FileDiscoverer(logger);

            using var service = new PhotoService(path, logger, fileDiscoverer);
            ServiceBase.Run(service);                        
        }
    }
}
