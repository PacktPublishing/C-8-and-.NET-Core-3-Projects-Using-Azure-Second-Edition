using System;
using System.IO;

namespace PhotoStorage.WindowsService
{
    internal class FileMonitor : IDisposable
    {
        private string _monitorPath;
        private FileSystemWatcher _fileSystemWatcher;

        public FileMonitor(string path)
        {
            _monitorPath = path;
            _fileSystemWatcher = new FileSystemWatcher(path);

            _fileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
            _fileSystemWatcher.Created += new FileSystemEventHandler(OnCreated);            
            _fileSystemWatcher.Renamed += new RenamedEventHandler(OnRenamed);
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _fileSystemWatcher.Dispose();
        }
    }
}