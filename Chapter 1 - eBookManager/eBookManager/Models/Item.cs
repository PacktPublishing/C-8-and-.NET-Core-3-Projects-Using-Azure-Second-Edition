using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace eBookManager.Models
{
    // https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/tree-view#tree-view-using-data-binding
    public class Item
    {
        public string Name { get; set; }
        public ObservableCollection<Item> Children { get; set; } = new ObservableCollection<Item>();
        public ItemType ItemType { get; set; }
        public string FullName { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public enum ItemType
    {
        Docx,
        Docxx,
        Pdfx,
        Epubx,
        Folder
    }

}
