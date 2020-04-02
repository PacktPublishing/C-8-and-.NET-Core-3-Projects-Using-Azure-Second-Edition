using System;
using System.Collections.Generic;
using System.Text;

namespace SalesOrder.Data.Helpers
{
    public interface ITextFileHelper
    {
        string GetContentTextFile(string filename);
    }
}
