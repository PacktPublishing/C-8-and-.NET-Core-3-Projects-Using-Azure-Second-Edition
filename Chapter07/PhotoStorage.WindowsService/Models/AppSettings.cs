using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStorage.WindowsService.Models
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string MonitorPath { get; set; }
    }
}
