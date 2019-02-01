using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStorage.WindowsService.Helpers
{
    public interface ILogger
    {
        void Log(string message);
    }
}
