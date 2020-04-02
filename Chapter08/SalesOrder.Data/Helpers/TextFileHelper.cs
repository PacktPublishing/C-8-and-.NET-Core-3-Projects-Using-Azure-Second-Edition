using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SalesOrder.Data.Helpers
{
    public class TextFileHelper : ITextFileHelper
    {
        public string GetContentTextFile(string filename)
        {
            return File.ReadAllText($"Assets/{filename}");
        }
    }
}
