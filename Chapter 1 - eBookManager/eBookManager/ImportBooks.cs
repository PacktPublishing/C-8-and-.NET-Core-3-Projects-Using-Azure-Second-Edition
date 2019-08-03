using eBookManager.Engine;
using Microsoft.Toolkit.Forms.UI.XamlHost;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml.Markup;
using static eBookManager.Helper.ExtensionMethods;
using static System.Math;

#nullable enable

namespace eBookManager
{
    public partial class ImportBooks : Form
    {
        private string _jsonPath;
        private List<StorageSpace> spaces;
        private enum StorageSpaceSelection { New = -9999, NoSelection = -1 }

        // C#7 (actually C# 6) - Expression-Bodied Property.
        private HashSet<string> AllowedExtensions => new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
        { ".doc", ".docx", ".pdf", ".epub", ".lit" };
                
        private enum Extention { doc = 0, docx = 1, pdf = 2, epub = 3, lit = 4 }               
        private Windows.UI.Xaml.Controls.TreeView? _tvFoundBooks = null;

        public ObservableCollection<Models.Item> DataSource { get; set; }

        public ImportBooks()
        {
            InitializeComponent();
            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");
            spaces = spaces.ReadFromDataStore(_jsonPath);

            var windowsXamlHostTreeView = new WindowsXamlHost();
            windowsXamlHostTreeView.InitialTypeName = "Windows.UI.Xaml.Controls.TreeView";
            windowsXamlHostTreeView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            windowsXamlHostTreeView.Location = new System.Drawing.Point(12, 60);
            windowsXamlHostTreeView.Name = "tvFoundBooks";
            windowsXamlHostTreeView.Size = new System.Drawing.Size(513, 350);
            windowsXamlHostTreeView.TabIndex = 8;
            windowsXamlHostTreeView.Dock = System.Windows.Forms.DockStyle.None;
            windowsXamlHostTreeView.ChildChanged += windowsXamlHostTreeView_ChildChanged;            

            this.Controls.Add(windowsXamlHostTreeView);

        }

        private void windowsXamlHostTreeView_ChildChanged(object? sender, EventArgs e)
        {
            if (sender == null) return;

            var host = (WindowsXamlHost)sender;
            _tvFoundBooks = (Windows.UI.Xaml.Controls.TreeView)host.Child;
            _tvFoundBooks.ItemInvoked += _tvFoundBooks_ItemInvoked;
            _tvFoundBooks.ItemsSource = DataSource;

            // https://stackoverflow.com/questions/57388908/binding-to-a-treeview-programatically-not-working-in-uwp
            const string Xaml = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><TreeViewItem ItemsSource=\"{Binding Children}\" Content=\"{Binding Name}\"/></DataTemplate>";
            var xaml = XamlReader.Load(Xaml);
            _tvFoundBooks.ItemTemplate = xaml as Windows.UI.Xaml.DataTemplate;


        }

        private void btnSelectSourceFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Select the location of your eBooks and documents";

                DialogResult dlgResult = fbd.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    UpdateBookList(fbd.SelectedPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateBookList(string path)
        {            
            DirectoryInfo di = new DirectoryInfo(path);
            var bookList = new List<Models.Item>();
            var rootItem = new Models.Item()
            {
                Name = di.Name
            };

            rootItem.ItemType = Models.ItemType.Folder;

            PopulateBookList(di.FullName, rootItem);
            bookList.Add(rootItem);

            DataSource = new ObservableCollection<Models.Item>(bookList);
            _tvFoundBooks.ItemsSource = DataSource.OrderBy(a => a.Name);
        }

        public void PopulateBookList(string paramDir, Models.Item rootItem)
        {
            if (rootItem == null)
                throw new ArgumentNullException();

            DirectoryInfo dir = new DirectoryInfo(paramDir);
            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
            {
                var item = new Models.Item();
                item.Name = dirInfo.Name;
                item.ItemType = Models.ItemType.Folder;

                rootItem.Children.Add(item);
                
                PopulateBookList(dirInfo.FullName, item);
            }
            foreach (FileInfo fleInfo in dir.GetFiles().Where(x => AllowedExtensions.Contains(x.Extension)).ToList())
            {
                var item = new Models.Item();
                item.Name = fleInfo.Name;

                item.FullName = fleInfo.FullName;
                item.ItemType = (Models.ItemType)Enum.Parse(typeof(Extention), fleInfo.Extension.TrimStart('.'), true);

                rootItem.Children.Add(item);
            }

        }

        private void _tvFoundBooks_ItemInvoked(Windows.UI.Xaml.Controls.TreeView sender, Windows.UI.Xaml.Controls.TreeViewItemInvokedEventArgs args)
        {
            var selectedItem = (Models.Item)args.InvokedItem;

            DocumentEngine engine = new DocumentEngine();
            string path = selectedItem.FullName.ToString();

            if (File.Exists(path))
            {
                var (dateCreated, dateLastAccessed, fileName, fileExtention, fileLength, hasError) = engine.GetFileProperties(selectedItem.FullName.ToString());

                if (!hasError)
                {
                    txtFileName.Text = fileName;
                    txtExtension.Text = fileExtention;
                    dtCreated.Value = dateCreated;
                    dtLastAccessed.Value = dateLastAccessed;
                    txtFilePath.Text = selectedItem.FullName.ToString();
                    txtFileSize.Text = $"{Round(fileLength.ToMegabytes(), 2).ToString()} MB";
                }
            }
        }

        private void ImportBooks_Load(object sender, EventArgs e)
        {
            // tvImages                        
            /*
            this.tvImages.Images.Add("docx16.png", Image.FromFile("img/docx16.png"));
            this.tvImages.Images.Add("docxx16.png", Image.FromFile("img/docxx16.png"));
            this.tvImages.Images.Add("pdfx16.png", Image.FromFile("img/pdfx16.png"));
            this.tvImages.Images.Add("epubx16.png", Image.FromFile("img/epubx16.png"));
            this.tvImages.Images.Add("folder-close-x16.png", Image.FromFile("img/folder-close-x16.png"));
            this.tvImages.Images.Add("folder_exp_x16.png", Image.FromFile("img/folder_exp_x16.png"));
            this.tvImages.TransparentColor = System.Drawing.Color.Transparent;
            */
            // btnAddeBookToStorageSpace
            this.btnAddeBookToStorageSpace.Image = Image.FromFile("img/add_ebook_to_storage_space.png");
            
            // btnAddNewStorageSpace
            this.btnAddNewStorageSpace.Image = Image.FromFile("img/add_new_storage_space.png");

            // ImportBooks            
            this.Icon = new System.Drawing.Icon("ico/importBooks.ico");


            PopulateStorageSpacesList();
                        
            if (dlVirtualStorageSpaces.Items.Count == 0)
            {
                dlVirtualStorageSpaces.Items.Add("<create new storage space>");
            }

            lblEbookCount.Text = "";
        }

        private void PopulateStorageSpacesList()
        {
            List<KeyValuePair<int, string>> lstSpaces = new List<KeyValuePair<int, string>>();
            BindStorageSpaceList((int)StorageSpaceSelection.NoSelection, "Select Storage Space");

            void BindStorageSpaceList(int key, string value) // Local function
            {
                lstSpaces.Add(new KeyValuePair<int, string>(key, value));
            }

            if (spaces is null || spaces.Count() == 0) // Pattern matching
            {
                BindStorageSpaceList((int)StorageSpaceSelection.New, "<create new>");
            }
            else
            {
                foreach (var space in spaces)
                {
                    BindStorageSpaceList(space.ID, space.Name);
                }
            }

            dlVirtualStorageSpaces.DataSource = new BindingSource(lstSpaces, null);
            dlVirtualStorageSpaces.DisplayMember = "Value";
            dlVirtualStorageSpaces.ValueMember = "Key";
        }

        private void dlVirtualStorageSpaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue = dlVirtualStorageSpaces.SelectedValue.ToString().ToInt();

            if (selectedValue == (int)StorageSpaceSelection.New) // -9999
            {
                txtNewStorageSpaceName.Visible = true;
                lblStorageSpaceDescription.Visible = true;
                txtStorageSpaceDescription.ReadOnly = false;
                btnSaveNewStorageSpace.Visible = true;
                btnCancelNewStorageSpaceSave.Visible = true;
                dlVirtualStorageSpaces.Enabled = false;
                btnAddNewStorageSpace.Enabled = false;
                lblEbookCount.Text = "";
            }
            else if (selectedValue != (int)StorageSpaceSelection.NoSelection)
            {
                // Find the contents of the selected storage space
                int contentCount = (from c in spaces
                                    where c.ID == selectedValue
                                    select c).Count();
                if (contentCount > 0)
                {
                    StorageSpace selectedSpace = (from c in spaces
                                                  where c.ID == selectedValue
                                                  select c).First();

                    txtStorageSpaceDescription.Text = selectedSpace.Description;

                    List<Document> eBooks = (selectedSpace.BookList == null) ? new List<Document> { } : selectedSpace.BookList;
                    lblEbookCount.Text = $"Storage Space contains {eBooks.Count()} {(eBooks.Count() == 1 ? "eBook" : "eBooks")}";
                }
            }
            else
            {
                lblEbookCount.Text = "";
            }
        }

        private void btnSaveNewStorageSpace_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewStorageSpaceName.Text.Length != 0)
                {
                    string newName = txtNewStorageSpaceName.Text;


                    // null conditional operator: "spaces?.StorageSpaceExists(newName) ?? false"
                    // throw expressions: bool spaceExists = (space exists = false) ? return false : throw exception                    
                    // Out variables
                    bool spaceExists = (!spaces.StorageSpaceExists(newName, out int nextID)) ? false : throw new Exception("The storage space you are trying to add already exists.");
                                        
                    if (!spaceExists)
                    {
                        StorageSpace newSpace = new StorageSpace(newName);                        
                        newSpace.ID = nextID;
                        newSpace.Description = txtStorageSpaceDescription.Text;
                        spaces.Add(newSpace);

                        PopulateStorageSpacesList();

                        // Save new Storage Space Name
                        txtNewStorageSpaceName.Clear();
                        txtNewStorageSpaceName.Visible = false;
                        lblStorageSpaceDescription.Visible = false;
                        txtStorageSpaceDescription.ReadOnly = true;
                        txtStorageSpaceDescription.Clear();
                        btnSaveNewStorageSpace.Visible = false;
                        btnCancelNewStorageSpaceSave.Visible = false;
                        dlVirtualStorageSpaces.Enabled = true;
                        btnAddNewStorageSpace.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                txtNewStorageSpaceName.SelectAll();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelNewStorageSpaceSave_Click(object sender, EventArgs e)
        {
            txtNewStorageSpaceName.Clear();
            txtNewStorageSpaceName.Visible = false;
            lblStorageSpaceDescription.Visible = false;
            txtStorageSpaceDescription.ReadOnly = true;
            txtStorageSpaceDescription.Clear();
            btnSaveNewStorageSpace.Visible = false;
            btnCancelNewStorageSpaceSave.Visible = false;
            dlVirtualStorageSpaces.Enabled = true;
            btnAddNewStorageSpace.Enabled = true;
        }

        private void btnAddNewStorageSpace_Click(object sender, EventArgs e)
        {
            txtNewStorageSpaceName.Visible = true;
            lblStorageSpaceDescription.Visible = true;
            txtStorageSpaceDescription.ReadOnly = false;
            btnSaveNewStorageSpace.Visible = true;
            btnCancelNewStorageSpaceSave.Visible = true;
            dlVirtualStorageSpaces.Enabled = false;
            btnAddNewStorageSpace.Enabled = false;
        }

        private void btnAddeBookToStorageSpace_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedStorageSpaceID = dlVirtualStorageSpaces.SelectedValue.ToString().ToInt();
                if ((selectedStorageSpaceID != (int)StorageSpaceSelection.NoSelection) && (selectedStorageSpaceID != (int)StorageSpaceSelection.New))
                {
                    UpdateStorageSpaceBooks(selectedStorageSpaceID);
                }
                else throw new Exception("Please select a Storage Space to add your eBook to"); // throw expressions
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStorageSpaceBooks(int storageSpaceId)
        {
            try
            {
                int iCount = (from s in spaces
                              where s.ID == storageSpaceId
                              select s).Count();
                if (iCount > 0) // The space will always exist
                {
                    // Update
                    StorageSpace existingSpace = (from s in spaces
                                                  where s.ID == storageSpaceId
                                                  select s).First();

                    List<Document> ebooks = existingSpace.BookList;

                    int iBooksExist = (ebooks != null) ? (from b in ebooks
                                                          where $"{b.FileName}".Equals($"{txtFileName.Text.Trim()}")
                                                          select b).Count() : 0;

                    if (iBooksExist > 0)
                    {
                        // Update existing book
                        DialogResult dlgResult = MessageBox.Show($"A book with the same name has been found in Storage Space {existingSpace.Name}. Do you want to replace the existing book entry with this one?", "Duplicate Title", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (dlgResult == DialogResult.Yes)
                        {
                            Document existingBook = (from b in ebooks
                                                     where $"{b.FileName}".Equals($"{txtFileName.Text.Trim()}")
                                                     select b).First();

                            existingBook.FileName = txtFileName.Text;
                            existingBook.Extension = txtExtension.Text;
                            existingBook.LastAccessed = dtLastAccessed.Value;
                            existingBook.Created = dtCreated.Value;
                            existingBook.FilePath = txtFilePath.Text;
                            existingBook.FileSize = txtFileSize.Text;
                            existingBook.Title = txtTitle.Text;
                            existingBook.Author = txtAuthor.Text;
                            existingBook.Publisher = txtPublisher.Text;
                            existingBook.Price = txtPrice.Text;
                            existingBook.ISBN = txtISBN.Text;
                            existingBook.PublishDate = dtDatePublished.Value;
                            existingBook.Category = txtCategory.Text;
                        }
                    }
                    else
                    {
                        // Insert new book
                        Document newBook = new Document();
                        newBook.FileName = txtFileName.Text;
                        newBook.Extension = txtExtension.Text;
                        newBook.LastAccessed = dtLastAccessed.Value;
                        newBook.Created = dtCreated.Value;
                        newBook.FilePath = txtFilePath.Text;
                        newBook.FileSize = txtFileSize.Text;
                        newBook.Title = txtTitle.Text;
                        newBook.Author = txtAuthor.Text;
                        newBook.Publisher = txtPublisher.Text;
                        newBook.Price = txtPrice.Text;
                        newBook.ISBN = txtISBN.Text;
                        newBook.PublishDate = dtDatePublished.Value;
                        newBook.Category = txtCategory.Text;
                        //newBook.Classification = dlClassification.SelectedText.ToString();

                        if (ebooks == null)
                            ebooks = new List<Document>();
                        ebooks.Add(newBook);
                        existingSpace.BookList = ebooks;
                    }

                }

                spaces.WriteToDataStore(_jsonPath);
                PopulateStorageSpacesList();
                MessageBox.Show("Book added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region ...
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        #endregion
                
    }
}
