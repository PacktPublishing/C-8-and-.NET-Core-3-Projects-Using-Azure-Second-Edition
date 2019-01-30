using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhotoStorage.Helpers.FileHelper
{
    public static class FileHelper
    {
        
        public static bool IsImage(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            return ext switch
            {
                "png" => true,
                "jpg" => true,
                "jpeg" => true,
                "bmp" => true,
                "gif" => true,                
                _ => false
            };            
        }
        
        /*
        public static bool IsImage(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext)
            {
                case "png":
                case "jpg":
                case "jpeg":
                case "bmp":
                case "gif":
                    return true;

                default: return false;
            };
        }
        */
    }
}
