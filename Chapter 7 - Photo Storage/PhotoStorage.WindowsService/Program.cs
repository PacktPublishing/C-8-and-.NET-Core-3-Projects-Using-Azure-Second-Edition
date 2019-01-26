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
            using (var service = new PhotoService())
            {
                ServiceBase.Run(service);
            }            
        }
    }
}
