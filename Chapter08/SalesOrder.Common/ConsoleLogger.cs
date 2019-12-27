using System;
using System.Collections.Generic;
using System.Text;

namespace SalesOrder.Common
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
