using eBookManager.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using eBookManager.Helper;
using System.Diagnostics;
using System.Linq;

namespace eBookManager
{
    public partial class eBookManager : Form
    {
        private string _jsonPath;
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
            this.imageList1.Images.Add("storage_space_cloud.png", Image.FromFile("img/storage_space_cloud.png"));
            this.imageList1.Images.Add("eBook.png", Image.FromFile("img/eBook.png"));
            this.imageList1.Images.Add("no_eBook.png", Image.FromFile("img/no_eBook.png"));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;

            // btnReadEbook                        
            this.btnReadEbook.Image = Image.FromFile("img/ReadEbook.png");
            this.btnReadEbook.Location = new System.Drawing.Point(103, 227);
            this.btnReadEbook.Name = "btnReadEbook";
            this.btnReadEbook.Size = new System.Drawing.Size(36, 40);
            this.btnReadEbook.TabIndex = 32;
            this.toolTip1.SetToolTip(this.btnReadEbook, "Click here to open the eBook file location");
            this.btnReadEbook.UseVisualStyleBackColor = true;
            this.btnReadEbook.Click += new System.EventHandler(this.btnReadEbook_Click);

            // eBookManager Icon            
            this.Icon = new System.Drawing.Icon("ico/mainForm.ico");

            PopulateStorageSpaceList();
        }
        private void PopulateStorageSpaceList()
        {
            lstStorageSpaces.Clear();
            if (!(_spaces == null))
            {
                foreach (StorageSpace space in _spaces)
                {
                    ListViewItem lvItem = new ListViewItem(space.Name, 0);
                    lvItem.Tag = space.BookList;
                    lvItem.Name = space.ID.ToString();
                    lstStorageSpaces.Items.Add(lvItem);
                }
            }
        }

        private void lstStorageSpaces_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedStorageSpace =
            lstStorageSpaces.SelectedItems[0];
            int spaceID = selectedStorageSpace.Name.ToInt();
            txtStorageSpaceDescription.Text = (from d in _spaces
                                               where d.ID == spaceID
                                               select d.Description).First();
            List<Document> ebookList =
                (List<Document>)selectedStorageSpace.Tag;
            PopulateContainedEbooks(ebookList);
        }

        private void PopulateContainedEbooks(List<Document> ebookList)
        {
            lstBooks.Clear();
            ClearSelectedBook();
            if (ebookList != null)
            {
                foreach (Document eBook in ebookList)
                {
                    ListViewItem book = new ListViewItem(eBook.Title, 1);
                    book.Tag = eBook;
                    lstBooks.Items.Add(book);
                }
            }
            else
            {
                ListViewItem book = new ListViewItem("This storage space contains no eBooks", 2);
                book.Tag = "";
                lstBooks.Items.Add(book);
            }
        }

        private void ClearSelectedBook()
        {
            foreach (Control ctrl in gbBookDetails.Controls)
            {
                if (ctrl is TextBox)
                    ctrl.Text = "";
            }
            foreach (Control ctrl in gbFileDetails.Controls)
            {
                if (ctrl is TextBox)
                    ctrl.Text = "";
            }
            dtLastAccessed.Value = DateTime.Now;
            dtCreated.Value = DateTime.Now;
            dtDatePublished.Value = DateTime.Now;
        }

        private async void mnuImportEbooks_Click(object sender, EventArgs e)
        {
            ImportBooks import = new ImportBooks();
            import.ShowDialog();
            _spaces = await _spaces.ReadFromDataStore(_jsonPath);
            PopulateStorageSpaceList();
        }

        private void lstBooks_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedBook = lstBooks.SelectedItems[0];
            if (!String.IsNullOrEmpty(selectedBook.Tag.ToString()))
            {
                Document ebook = (Document)selectedBook.Tag;
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
            string filePath = txtFilePath.Text;
            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                Process.Start("explorer.exe", Path.GetDirectoryName(filePath));
            }
        }
    }
}
