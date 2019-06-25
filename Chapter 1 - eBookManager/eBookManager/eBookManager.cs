using eBookManager.Engine;
using eBookManager.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using System.Drawing;

#nullable enable

namespace eBookManager
{
    public partial class eBookManager : Form
    {
        private string _jsonPath;
        private List<StorageSpace> spaces;

        public eBookManager()
        {
            InitializeComponent();

            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");

            spaces = spaces.ReadFromDataStore(_jsonPath);

            this.windowsXamlHost.InitialTypeName = "eBookManager.Controls.CustomProgressBar";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(eBookManager));

            this.components = new System.ComponentModel.Container();

            // imageList1
            //this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));            
            this.imageList1.Images.Add("storage_space_cloud.png", Image.FromFile("img/storage_space_cloud.png"));
            this.imageList1.Images.Add("eBook.png", Image.FromFile("img/eBook.png"));
            this.imageList1.Images.Add("no_eBook.png", Image.FromFile("img/no_eBook.png"));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;

            // btnReadEbook            
            //this.btnReadEbook.Image = global::eBookManager.Properties.Resources.ReadEbook;
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
            if (!(spaces == null))
            {
                foreach (StorageSpace space in spaces)
                {
                    ListViewItem lvItem = new ListViewItem(space.Name, 0);
                    lvItem.Tag = space.BookList;
                    lvItem.Name = space.ID.ToString();
                    lstStorageSpaces.Items.Add(lvItem);
                }
            }
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

        private void mnuImportEbooks_Click(object sender, EventArgs e)
        {
            ImportBooks import = new ImportBooks();
            import.ShowDialog();
            spaces = spaces.ReadFromDataStore(_jsonPath);
            PopulateStorageSpaceList();
        }

        private void lstStorageSpaces_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedStorageSpace = lstStorageSpaces.SelectedItems[0];
            int spaceID = selectedStorageSpace.Name.ToInt();

            txtStorageSpaceDescription.Text = (from d in spaces
                                               where d.ID == spaceID
                                               select d.Description).First();

            List<Document> ebookList = (List<Document>)selectedStorageSpace.Tag;
            PopulateContainedEbooks(ebookList);
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
                var processStartInfo = new ProcessStartInfo(filePath, Path.GetDirectoryName(filePath))
                {
                    // Change in .Net Core - this defaulted to true in WinForms
                    UseShellExecute = true
                };
                Process.Start(processStartInfo);
            }
        }
    }
}
