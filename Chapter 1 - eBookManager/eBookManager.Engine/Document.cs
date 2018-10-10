using System;

namespace eBookManager.Engine
{
    public class Document
    {
        //private DateTime _defaultDate;
        //public Document() => _defaultDate = DateTime.Now;
        
        public string Title { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public DateTime LastAccessed { get; set; }
        public DateTime Created { get; set; }
        public string FilePath { get; set; }
        public string FileSize { get; set; }
        public string ISBN { get; set; }
        public string Price { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public DeweyDecimal Classification { get; set; }
        public string Category { get; set; }

        
    }
}
