using eBookManager.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static eBookManager.Helper.ExtensionMethods;
using static System.Math;

namespace eBookManager
{
    public partial class ImportBooks : Form
    {
        private readonly string _jsonPath;
        private List<StorageSpace> _spaces;

        private enum _storageSpaceSelection
        {
            New = -9999, NoSelection = -1
        }

        private enum Extension { doc = 0, docx = 1, pdf = 2, epub = 3, lit = 4 }

        private HashSet<string> AllowedExtensions => new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
        { ".doc", ".docx", ".pdf", ".epub", ".lit" };

        public ImportBooks()
        {
            InitializeComponent();
            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");
        }

        public void PopulateBookList(string paramDir, TreeNode paramNode)
        {
            DirectoryInfo dir = new DirectoryInfo(paramDir);
            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
            {
                TreeNode node = new TreeNode(dirInfo.Name)
                {
                    ImageIndex = 4,
                    SelectedImageIndex = 5
                };
                if (paramNode != null)
                    paramNode.Nodes.Add(node);
                else
                    tvFoundBooks.Nodes.Add(node);
                PopulateBookList(dirInfo.FullName, node);
            }
            foreach (FileInfo fleInfo in dir.GetFiles().Where
            (x => AllowedExtensions.Contains(x.Extension)).ToList())
            {
                TreeNode node = new TreeNode(fleInfo.Name)
                {
                    Tag = fleInfo.FullName
                };
                int iconIndex = Enum.Parse(typeof(Extension),
                fleInfo.Extension.TrimStart('.'), true).GetHashCode();
                node.ImageIndex = iconIndex;
                node.SelectedImageIndex = iconIndex;
                if (paramNode != null)
                    paramNode.Nodes.Add(node);
                else
                    tvFoundBooks.Nodes.Add(node);
            }
        }

        private void PopulateStorageSpacesList()
        {
            List<KeyValuePair<int, string>> lstSpaces =
            new List<KeyValuePair<int, string>>();
            BindStorageSpaceList((int)_storageSpaceSelection.NoSelection, "Select Storage Space");

            void BindStorageSpaceList(int key, string value) =>
                lstSpaces.Add(new KeyValuePair<int, string>(key, value));

            if (_spaces is null || _spaces.Count == 0) // Pattern matching
            {
                BindStorageSpaceList((int)_storageSpaceSelection.New, " <create new> ");
            }
            else
            {
                foreach (var space in _spaces)
                {
                    BindStorageSpaceList(space.ID, space.Name);
                }
            }
            dlVirtualStorageSpaces.DataSource = new
                BindingSource(lstSpaces, null);
            dlVirtualStorageSpaces.DisplayMember = "Value";
            dlVirtualStorageSpaces.ValueMember = "Key";
        }

        private async void ImportBooks_Load(object sender, EventArgs e)
        {
            _spaces = await _spaces.ReadFromDataStore(_jsonPath);

            PopulateStorageSpacesList();
            if (dlVirtualStorageSpaces.Items.Count == 0)
            {
                dlVirtualStorageSpaces.Items.Add("<create new storage space > ");
            }
            lblEbookCount.Text = "";
        }

        private void btnSelectSourceFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog
                {
                    Description = "Select the location of your eBooks and documents"
                };
                DialogResult dlgResult = fbd.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    tvFoundBooks.Nodes.Clear();
                    string path = fbd.SelectedPath;
                    DirectoryInfo di = new DirectoryInfo(path);
                    TreeNode root = new TreeNode(di.Name)
                    {
                        ImageIndex = 4,
                        SelectedImageIndex = 5
                    };
                    tvFoundBooks.Nodes.Add(root);
                    PopulateBookList(di.FullName, root);
                    tvFoundBooks.Sort();
                    root.Expand();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tvFoundBooks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DocumentEngine engine = new DocumentEngine();
            string path = e.Node.Tag?.ToString() ?? "";
            if (File.Exists(path))
            {
                var (dateCreated, dateLastAccessed, fileName,
                fileExtention, fileLength, hasError) =
                engine.GetFileProperties(e.Node.Tag.ToString());
                if (!hasError)
                {
                    txtFileName.Text = fileName;
                    txtExtension.Text = fileExtention;
                    dtCreated.Value = dateCreated;
                    dtLastAccessed.Value = dateLastAccessed;
                    txtFilePath.Text = e.Node.Tag.ToString();
                    txtFileSize.Text = $"{Round(fileLength.ToMegabytes(), 2)} MB";
                }
            }
        }

        private void dlVirtualStorageSpaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue = dlVirtualStorageSpaces.SelectedValue.ToString().ToInt();
            if (selectedValue == (int)_storageSpaceSelection.New) // -9999
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
            else if (selectedValue != (int)_storageSpaceSelection.NoSelection)
            {
                // Find the contents of the selected storage space
                int contentCount = (from c in _spaces
                                    where c.ID == selectedValue
                                    select c).Count();
                if (contentCount > 0)
                {
                    StorageSpace selectedSpace = (from c in _spaces
                                                  where c.ID == selectedValue
                                                  select c).First();
                    txtStorageSpaceDescription.Text =
                    selectedSpace.Description;
                    List<Document> eBooks = selectedSpace.BookList ?? new List<Document>();
                    lblEbookCount.Text = $"Storage Space contains { eBooks.Count} {(eBooks.Count == 1 ? "eBook" : "eBooks")}";
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
                    bool spaceExists =
                        (!_spaces.StorageSpaceExists(newName, out int nextID))
                        ? false
                        : throw new Exception("The storage space you are trying to add already exists.");
                    if (!spaceExists)
                    {
                        StorageSpace newSpace = new StorageSpace
                        {
                            Name = newName,
                            ID = nextID,
                            Description = txtStorageSpaceDescription.Text
                        };
                        _spaces.Add(newSpace);

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

        private async void btnAddeBookToStorageSpace_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedStorageSpaceID =
                dlVirtualStorageSpaces.SelectedValue.ToString().ToInt();
                if ((selectedStorageSpaceID != (int)_storageSpaceSelection.NoSelection)
                && (selectedStorageSpaceID != (int)_storageSpaceSelection.New))
                {
                    await UpdateStorageSpaceBooks(selectedStorageSpaceID);
                }
                else
                {
                    throw new Exception("Please select a Storage Space to add your eBook to"); // throw expressions
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task UpdateStorageSpaceBooks(int storageSpaceId)
        {
            try
            {
                int iCount = (from s in _spaces
                              where s.ID == storageSpaceId
                              select s).Count();
                if (iCount > 0) // The space will always exist             
                {
                    // Update
                    StorageSpace existingSpace = (from s in _spaces
                                                  where s.ID == storageSpaceId
                                                  select s).First();
                    List<Document> ebooks = existingSpace.BookList;
                    int iBooksExist = (ebooks != null) ? (from b in ebooks
                                                          where $"{b.FileName}".Equals($"{txtFileName.Text.Trim()}")
                                                          select b).Count() : 0;
                    if (iBooksExist > 0)
                    {
                        DialogResult dlgResult = MessageBox.Show($"A book with the same name has been found in Storage Space {existingSpace.Name}. Do you want to replace the existing book entry with this one ?",
                            "Duplicate Title", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2);
                        if (dlgResult == DialogResult.Yes)
                        {
                            Document existingBook = (from b in ebooks
                                                     where $"{ b.FileName}".Equals($"{txtFileName.Text.Trim()}")
                                                     select b).First();
                            SetBookFields(existingBook);
                        }
                    }
                    else
                    {
                        // Insert new book
                        Document newBook = new Document();
                        SetBookFields(newBook);
                        (ebooks ??= new List<Document>()).Add(newBook);
                        existingSpace.BookList = ebooks;
                    }
                }
                await _spaces.WriteToDataStore(_jsonPath);
                PopulateStorageSpacesList();
                MessageBox.Show("Book added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetBookFields(Document book)
        {
            book.FileName = txtFileName.Text;
            book.Extension = txtExtension.Text;
            book.LastAccessed = dtLastAccessed.Value;
            book.Created = dtCreated.Value;
            book.FilePath = txtFilePath.Text;
            book.FileSize = txtFileSize.Text;
            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.Publisher = txtPublisher.Text;
            book.Price = txtPrice.Text;
            book.ISBN = txtISBN.Text;
            book.PublishDate = dtDatePublished.Value;
            book.Category = txtCategory.Text;
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
    }
}
