using System;
using System.Collections.Generic;
namespace eBookManager.Engine
{
    [Serializable]
    public class StorageSpace
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Document> BookList { get; set; }
    }
}