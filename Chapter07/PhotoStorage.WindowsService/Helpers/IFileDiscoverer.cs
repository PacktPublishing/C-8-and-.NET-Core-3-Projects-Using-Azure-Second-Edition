using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStorage.WindowsService.Helpers
{
    public interface IFileDiscoverer
    {
        void DiscoverFiles(string directory, Action<string> action);
    }
}
