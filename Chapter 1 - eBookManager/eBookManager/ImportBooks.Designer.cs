using eBookManager.Controls;

namespace eBookManager
{
    partial class ImportBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportBooks));
            this.btnSelectSourceFolder = new System.Windows.Forms.Button();
            this.tvFoundBooks = new System.Windows.Forms.TreeView();
            this.tvImages = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dlClassification = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtDatePublished = new System.Windows.Forms.DateTimePicker();
            this.dtCreated = new System.Windows.Forms.DateTimePicker();
            this.dtLastAccessed = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.MaskedTextBox();
            this.btnAddeBookToStorageSpace = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStorageSpaceDescription = new System.Windows.Forms.Label();
            this.txtStorageSpaceDescription = new System.Windows.Forms.TextBox();
            this.btnAddNewStorageSpace = new System.Windows.Forms.Button();
            this.btnCancelNewStorageSpaceSave = new System.Windows.Forms.Button();
            this.btnSaveNewStorageSpace = new System.Windows.Forms.Button();
            this.txtNewStorageSpaceName = new System.Windows.Forms.TextBox();
            this.dlVirtualStorageSpaces = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblEbookCount = new System.Windows.Forms.Label();

            this.progressBar = new CustomProgressBar();

            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectSourceFolder
            // 
            this.btnSelectSourceFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSelectSourceFolder.Name = "btnSelectSourceFolder";
            this.btnSelectSourceFolder.Size = new System.Drawing.Size(113, 23);
            this.btnSelectSourceFolder.TabIndex = 0;
            this.btnSelectSourceFolder.Text = "Select source folder";
            this.btnSelectSourceFolder.UseVisualStyleBackColor = true;
            this.btnSelectSourceFolder.Click += new System.EventHandler(this.btnSelectSourceFolder_Click);
            // 
            // tvFoundBooks
            // 
            this.tvFoundBooks.Location = new System.Drawing.Point(12, 41);
            this.tvFoundBooks.Name = "tvFoundBooks";
            this.tvFoundBooks.Size = new System.Drawing.Size(513, 246);
            this.tvFoundBooks.TabIndex = 8;
            this.tvFoundBooks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFoundBooks_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Created:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File path:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Size:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtFileSize
            // 
            this.txtFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileSize.Location = new System.Drawing.Point(103, 148);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.ReadOnly = true;
            this.txtFileSize.Size = new System.Drawing.Size(239, 20);
            this.txtFileSize.TabIndex = 99;
            this.txtFileSize.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(103, 122);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(239, 20);
            this.txtFilePath.TabIndex = 99;
            this.txtFilePath.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtExtension
            // 
            this.txtExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtension.Location = new System.Drawing.Point(103, 44);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.ReadOnly = true;
            this.txtExtension.Size = new System.Drawing.Size(239, 20);
            this.txtExtension.TabIndex = 99;
            this.txtExtension.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(103, 18);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(239, 20);
            this.txtFileName.TabIndex = 99;
            this.txtFileName.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(103, 18);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(239, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "File name:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Title:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Last accessed:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "File extension:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtPublisher
            // 
            this.txtPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublisher.Location = new System.Drawing.Point(103, 70);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(239, 20);
            this.txtPublisher.TabIndex = 2;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Location = new System.Drawing.Point(103, 44);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(239, 20);
            this.txtAuthor.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Author:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Price:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Publisher:";
            // 
            // txtISBN
            // 
            this.txtISBN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtISBN.Location = new System.Drawing.Point(103, 122);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(239, 20);
            this.txtISBN.TabIndex = 4;
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.Location = new System.Drawing.Point(103, 174);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(239, 20);
            this.txtCategory.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Category";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Date published:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "ISBN:";
            // 
            // dlClassification
            // 
            this.dlClassification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlClassification.FormattingEnabled = true;
            this.dlClassification.Location = new System.Drawing.Point(103, 200);
            this.dlClassification.Name = "dlClassification";
            this.dlClassification.Size = new System.Drawing.Size(239, 21);
            this.dlClassification.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 203);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Classification:";
            // 
            // dtDatePublished
            // 
            this.dtDatePublished.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDatePublished.Location = new System.Drawing.Point(103, 148);
            this.dtDatePublished.Name = "dtDatePublished";
            this.dtDatePublished.Size = new System.Drawing.Size(239, 20);
            this.dtDatePublished.TabIndex = 5;
            // 
            // dtCreated
            // 
            this.dtCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtCreated.Enabled = false;
            this.dtCreated.Location = new System.Drawing.Point(103, 99);
            this.dtCreated.Name = "dtCreated";
            this.dtCreated.Size = new System.Drawing.Size(239, 20);
            this.dtCreated.TabIndex = 99;
            // 
            // dtLastAccessed
            // 
            this.dtLastAccessed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtLastAccessed.Enabled = false;
            this.dtLastAccessed.Location = new System.Drawing.Point(103, 73);
            this.dtLastAccessed.Name = "dtLastAccessed";
            this.dtLastAccessed.Size = new System.Drawing.Size(239, 20);
            this.dtLastAccessed.TabIndex = 99;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.btnAddeBookToStorageSpace);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dtDatePublished);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtCategory);
            this.groupBox1.Controls.Add(this.dlClassification);
            this.groupBox1.Controls.Add(this.txtISBN);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtPublisher);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtAuthor);
            this.groupBox1.Location = new System.Drawing.Point(531, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 257);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Book details";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(103, 96);
            this.txtPrice.Mask = "$999,999.00";
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(239, 20);
            this.txtPrice.TabIndex = 3;
            // 
            // btnAddeBookToStorageSpace
            //                         
            this.btnAddeBookToStorageSpace.Location = new System.Drawing.Point(103, 227);
            this.btnAddeBookToStorageSpace.Name = "btnAddeBookToStorageSpace";
            this.btnAddeBookToStorageSpace.Size = new System.Drawing.Size(23, 23);
            this.btnAddeBookToStorageSpace.TabIndex = 32;
            this.toolTip.SetToolTip(this.btnAddeBookToStorageSpace, "Add eBook to selected Storage Space");
            this.btnAddeBookToStorageSpace.UseVisualStyleBackColor = true;
            this.btnAddeBookToStorageSpace.Click += new System.EventHandler(this.btnAddeBookToStorageSpace_Click);            
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtLastAccessed);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtCreated);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtExtension);
            this.groupBox2.Controls.Add(this.txtFileSize);
            this.groupBox2.Controls.Add(this.txtFileName);
            this.groupBox2.Controls.Add(this.txtFilePath);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(531, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 182);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File details";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblEbookCount);
            this.groupBox3.Controls.Add(this.lblStorageSpaceDescription);
            this.groupBox3.Controls.Add(this.txtStorageSpaceDescription);
            this.groupBox3.Controls.Add(this.btnAddNewStorageSpace);
            this.groupBox3.Controls.Add(this.btnCancelNewStorageSpaceSave);
            this.groupBox3.Controls.Add(this.btnSaveNewStorageSpace);
            this.groupBox3.Controls.Add(this.txtNewStorageSpaceName);
            this.groupBox3.Controls.Add(this.dlVirtualStorageSpaces);
            this.groupBox3.Location = new System.Drawing.Point(12, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(513, 245);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Virtual storage spaces";
            // 
            // lblStorageSpaceDescription
            // 
            this.lblStorageSpaceDescription.AutoSize = true;
            this.lblStorageSpaceDescription.Location = new System.Drawing.Point(247, 52);
            this.lblStorageSpaceDescription.Name = "lblStorageSpaceDescription";
            this.lblStorageSpaceDescription.Size = new System.Drawing.Size(137, 13);
            this.lblStorageSpaceDescription.TabIndex = 6;
            this.lblStorageSpaceDescription.Text = "Storage Space Description:";
            // 
            // txtStorageSpaceDescription
            // 
            this.txtStorageSpaceDescription.Location = new System.Drawing.Point(248, 68);
            this.txtStorageSpaceDescription.Multiline = true;
            this.txtStorageSpaceDescription.Name = "txtStorageSpaceDescription";
            this.txtStorageSpaceDescription.ReadOnly = true;
            this.txtStorageSpaceDescription.Size = new System.Drawing.Size(259, 118);
            this.txtStorageSpaceDescription.TabIndex = 5;
            // 
            // btnAddNewStorageSpace
            // 
            this.btnAddNewStorageSpace.Location = new System.Drawing.Point(219, 17);
            this.btnAddNewStorageSpace.Name = "btnAddNewStorageSpace";
            this.btnAddNewStorageSpace.Size = new System.Drawing.Size(23, 23);
            this.btnAddNewStorageSpace.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnAddNewStorageSpace, "Add new Storage Space");
            this.btnAddNewStorageSpace.UseVisualStyleBackColor = true;
            this.btnAddNewStorageSpace.Click += new System.EventHandler(this.btnAddNewStorageSpace_Click);
            // 
            // btnCancelNewStorageSpaceSave
            // 
            this.btnCancelNewStorageSpaceSave.Location = new System.Drawing.Point(457, 17);
            this.btnCancelNewStorageSpaceSave.Name = "btnCancelNewStorageSpaceSave";
            this.btnCancelNewStorageSpaceSave.Size = new System.Drawing.Size(50, 23);
            this.btnCancelNewStorageSpaceSave.TabIndex = 3;
            this.btnCancelNewStorageSpaceSave.Text = "cancel";
            this.btnCancelNewStorageSpaceSave.UseVisualStyleBackColor = true;
            this.btnCancelNewStorageSpaceSave.Visible = false;
            this.btnCancelNewStorageSpaceSave.Click += new System.EventHandler(this.btnCancelNewStorageSpaceSave_Click);
            // 
            // btnSaveNewStorageSpace
            // 
            this.btnSaveNewStorageSpace.Location = new System.Drawing.Point(401, 17);
            this.btnSaveNewStorageSpace.Name = "btnSaveNewStorageSpace";
            this.btnSaveNewStorageSpace.Size = new System.Drawing.Size(50, 23);
            this.btnSaveNewStorageSpace.TabIndex = 2;
            this.btnSaveNewStorageSpace.Text = "save";
            this.btnSaveNewStorageSpace.UseVisualStyleBackColor = true;
            this.btnSaveNewStorageSpace.Visible = false;
            this.btnSaveNewStorageSpace.Click += new System.EventHandler(this.btnSaveNewStorageSpace_Click);
            // 
            // txtNewStorageSpaceName
            // 
            this.txtNewStorageSpaceName.Location = new System.Drawing.Point(248, 19);
            this.txtNewStorageSpaceName.Name = "txtNewStorageSpaceName";
            this.txtNewStorageSpaceName.Size = new System.Drawing.Size(147, 20);
            this.txtNewStorageSpaceName.TabIndex = 1;
            this.txtNewStorageSpaceName.Visible = false;
            // 
            // dlVirtualStorageSpaces
            // 
            this.dlVirtualStorageSpaces.FormattingEnabled = true;
            this.dlVirtualStorageSpaces.Location = new System.Drawing.Point(6, 19);
            this.dlVirtualStorageSpaces.Name = "dlVirtualStorageSpaces";
            this.dlVirtualStorageSpaces.Size = new System.Drawing.Size(207, 21);
            this.dlVirtualStorageSpaces.TabIndex = 0;
            this.dlVirtualStorageSpaces.SelectedIndexChanged += new System.EventHandler(this.dlVirtualStorageSpaces_SelectedIndexChanged);
            // 
            // lblEbookCount
            // 
            this.lblEbookCount.AutoSize = true;
            this.lblEbookCount.Location = new System.Drawing.Point(6, 52);
            this.lblEbookCount.Name = "lblEbookCount";
            this.lblEbookCount.Size = new System.Drawing.Size(76, 13);
            this.lblEbookCount.TabIndex = 7;
            this.lblEbookCount.Text = "lbleBookCount";
            //
            // progressBar
            //
            //this.progressBar.po

            // 
            // ImportBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 556);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvFoundBooks);
            this.Controls.Add(this.btnSelectSourceFolder);
            this.Controls.Add(this.progressBar);
            this.Name = "ImportBooks";
            this.Text = " Import eBooks";
            this.Load += new System.EventHandler(this.ImportBooks_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectSourceFolder;
        private System.Windows.Forms.TreeView tvFoundBooks;
        private System.Windows.Forms.ImageList tvImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox dlClassification;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtDatePublished;
        private System.Windows.Forms.DateTimePicker dtCreated;
        private System.Windows.Forms.DateTimePicker dtLastAccessed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox dlVirtualStorageSpaces;
        private System.Windows.Forms.Button btnSaveNewStorageSpace;
        private System.Windows.Forms.TextBox txtNewStorageSpaceName;
        private System.Windows.Forms.Button btnCancelNewStorageSpaceSave;
        private System.Windows.Forms.Button btnAddNewStorageSpace;
        private System.Windows.Forms.Button btnAddeBookToStorageSpace;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox txtStorageSpaceDescription;
        private System.Windows.Forms.Label lblStorageSpaceDescription;
        private System.Windows.Forms.MaskedTextBox txtPrice;
        private System.Windows.Forms.Label lblEbookCount;
        private CustomProgressBar progressBar;
    }
}