using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhotoStorage.WindowsService.Helpers
{
    public class FileLogger : ILogger
    {
        private readonly string _loggingPath;

        public FileLogger(string loggingPath)
        {
            _loggingPath = loggingPath;
        }

        public void Log(string message)
        {
            File.AppendAllText($@"{_loggingPath}\PhotoStorage.Log.txt", $"{DateTime.Now} : {message}{Environment.NewLine}");
        }
    }
}
