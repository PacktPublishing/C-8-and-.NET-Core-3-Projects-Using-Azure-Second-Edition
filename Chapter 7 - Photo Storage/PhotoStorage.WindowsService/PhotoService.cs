using System;
using System.ServiceProcess;

namespace PhotoStorage.WindowsService
{
    public class PhotoService : ServiceBase
    {
        private FileMonitor _fileMonitor;

        protected override void OnStart(string[] args)
        {
            _fileMonitor = new FileMonitor("c:\tmp");
        }

        protected override void OnStop()
        {
            _fileMonitor.Dispose();
        }
    }
}
