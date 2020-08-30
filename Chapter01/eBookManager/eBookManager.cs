using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using eBookManager.Engine;
using eBookManager.Helper;

namespace eBookManager
{
    public partial class eBookManager : Form
    {
        private readonly string _jsonPath;
        private List<StorageSpace> _spaces;

        public eBookManager()
        {
            InitializeComponent();
            _jsonPath = Path.Combine(Application.StartupPath,
                "bookData.txt");
        }

        private async void eBookManager_Load(object sender, EventArgs e)
        {
            _spaces = await _spaces.ReadFromDataStore(_jsonPath);

            // imageList1            
            imageList1.Images.Add("storage_space_cloud.png", Image.FromFile("img/storage_space_cloud.png"));
            imageList1.Images.Add("eBook.png", Image.FromFile("img/eBook.png"));
            imageList1.Images.Add("no_eBook.png", Image.FromFile("img/no_eBook.png"));
            imageList1.TransparentColor = System.Drawing.Color.Transparent;

            // btnReadEbook                        
            btnReadEbook.Image = Image.FromFile("img/ReadEbook.png");
            btnReadEbook.Location = new System.Drawing.Point(103, 227);
            btnReadEbook.Name = "btnReadEbook";
            btnReadEbook.Size = new System.Drawing.Size(36, 40);
            btnReadEbook.TabIndex = 32;
            toolTip1.SetToolTip(btnReadEbook, "Click here to open the eBook file location");
            btnReadEbook.UseVisualStyleBackColor = true;
            btnReadEbook.Click += btnReadEbook_Click;

            // eBookManager Icon            
            Icon = new System.Drawing.Icon("ico/mainForm.ico");

            PopulateStorageSpaceList();
        }

        private void PopulateStorageSpaceList()
        {
            lstStorageSpaces.Clear();
            if (_spaces == null)
            {
                return;
            }
            foreach (var space in _spaces)
            {
                var lvItem = new ListViewItem(space.Name, 0)
                {
                    Tag = space.BookList,
                    Name = space.ID.ToString()
                };
                lstStorageSpaces.Items.Add(lvItem);
            }
        }

        private void lstStorageSpaces_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedStorageSpace =
            lstStorageSpaces.SelectedItems[0];
            var spaceID = selectedStorageSpace.Name.ToInt();
            txtStorageSpaceDescription.Text = (from d in _spaces
                                               where d.ID == spaceID
                                               select d.Description).First();
            PopulateContainedEbooks((List<Document>)selectedStorageSpace.Tag);
        }

        private void PopulateContainedEbooks(List<Document> ebookList)
        {
            lstBooks.Clear();
            ClearSelectedBook();
            if (ebookList != null)
            {
                foreach (var eBook in ebookList)
                {
                    var book = new ListViewItem(eBook.Title, 1)
                    {
                        Tag = eBook
                    };
                    lstBooks.Items.Add(book);
                }
            }
            else
            {
                var book = new ListViewItem("This storage space contains no eBooks", 2) { Tag = "" };
                lstBooks.Items.Add(book);
            }
        }

        private void ClearSelectedBook()
        {
            foreach (Control ctrl in gbBookDetails.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }
            foreach (Control ctrl in gbFileDetails.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }
            dtLastAccessed.Value = DateTime.Now;
            dtCreated.Value = DateTime.Now;
            dtDatePublished.Value = DateTime.Now;
        }

        private async void mnuImportEbooks_Click(object sender, EventArgs e)
        {
            var import = new ImportBooks();
            import.ShowDialog();
            _spaces = await _spaces.ReadFromDataStore(_jsonPath);
            PopulateStorageSpaceList();
        }

        private void lstBooks_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedBook = lstBooks.SelectedItems[0];
            if (!string.IsNullOrEmpty(selectedBook.Tag.ToString()))
            {
                var ebook = (Document)selectedBook.Tag;
                txtFileName.Text = ebook.FileName;
                txtExtension.Text = ebook.Extension;
                dtLastAccessed.Value = ebook.LastAccessed;
                dtCreated.Value = ebook.Created;
                txtFilePath.Text = ebook.FilePath;
                txtFileSize.Text = ebook.FileSize;
                txtTitle.Text = ebook.Title;
                txtAuthor.Text = ebook.Author;
                txtPublisher.Text = ebook.Publisher;
                txtPrice.Text = ebook.Price;
                txtISBN.Text = ebook.ISBN;
                dtDatePublished.Value = ebook.PublishDate;
                txtCategory.Text = ebook.Category;
            }
        }

        private void btnReadEbook_Click(object sender, EventArgs e)
        {
            var filePath = txtFilePath.Text;
            var fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                Process.Start("explorer.exe", Path.GetDirectoryName(filePath));
            }
        }
    }
}
