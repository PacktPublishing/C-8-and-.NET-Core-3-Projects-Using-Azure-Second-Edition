namespace eBookManager
{
    partial class eBookManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(eBookManager));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportEbooks = new System.Windows.Forms.ToolStripMenuItem();
            this.lstStorageSpaces = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstBooks = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbFileDetails = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtLastAccessed = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtCreated = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbBookDetails = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtDatePublished = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.dlClassification = new System.Windows.Forms.ComboBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtStorageSpaceDescription = new System.Windows.Forms.TextBox();
            this.btnReadEbook = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbFileDetails.SuspendLayout();
            this.gbBookDetails.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1113, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportEbooks});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuImportEbooks
            // 
            this.mnuImportEbooks.Name = "mnuImportEbooks";
            this.mnuImportEbooks.Size = new System.Drawing.Size(151, 22);
            this.mnuImportEbooks.Text = "Import eBooks";
            this.mnuImportEbooks.Click += new System.EventHandler(this.mnuImportEbooks_Click);
            // 
            // lstStorageSpaces
            // 
            this.lstStorageSpaces.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstStorageSpaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstStorageSpaces.HotTracking = true;
            this.lstStorageSpaces.HoverSelection = true;
            this.lstStorageSpaces.LargeImageList = this.imageList1;
            this.lstStorageSpaces.Location = new System.Drawing.Point(6, 19);
            this.lstStorageSpaces.Name = "lstStorageSpaces";
            this.lstStorageSpaces.Size = new System.Drawing.Size(246, 579);
            this.lstStorageSpaces.TabIndex = 1;
            this.lstStorageSpaces.UseCompatibleStateImageBehavior = false;
            this.lstStorageSpaces.View = System.Windows.Forms.View.Tile;
            this.lstStorageSpaces.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstStorageSpaces_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lstStorageSpaces);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 604);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Virtual Storage Spaces";
            // 
            // lstBooks
            // 
            this.lstBooks.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBooks.HotTracking = true;
            this.lstBooks.HoverSelection = true;
            this.lstBooks.Location = new System.Drawing.Point(6, 19);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(448, 579);
            this.lstBooks.SmallImageList = this.imageList1;
            this.lstBooks.StateImageList = this.imageList1;
            this.lstBooks.TabIndex = 3;
            this.lstBooks.UseCompatibleStateImageBehavior = false;
            this.lstBooks.View = System.Windows.Forms.View.List;
            this.lstBooks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstBooks_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lstBooks);
            this.groupBox2.Location = new System.Drawing.Point(276, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 604);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "eBooks in Virtual Storage Space";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.gbBookDetails);
            this.groupBox3.Controls.Add(this.gbFileDetails);
            this.groupBox3.Location = new System.Drawing.Point(742, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(365, 604);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "eBook Info";
            // 
            // gbFileDetails
            // 
            this.gbFileDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFileDetails.Controls.Add(this.label1);
            this.gbFileDetails.Controls.Add(this.dtLastAccessed);
            this.gbFileDetails.Controls.Add(this.label2);
            this.gbFileDetails.Controls.Add(this.dtCreated);
            this.gbFileDetails.Controls.Add(this.label3);
            this.gbFileDetails.Controls.Add(this.txtExtension);
            this.gbFileDetails.Controls.Add(this.txtFileSize);
            this.gbFileDetails.Controls.Add(this.txtFileName);
            this.gbFileDetails.Controls.Add(this.txtFilePath);
            this.gbFileDetails.Controls.Add(this.label8);
            this.gbFileDetails.Controls.Add(this.label5);
            this.gbFileDetails.Controls.Add(this.label7);
            this.gbFileDetails.Location = new System.Drawing.Point(6, 19);
            this.gbFileDetails.Name = "gbFileDetails";
            this.gbFileDetails.Size = new System.Drawing.Size(352, 182);
            this.gbFileDetails.TabIndex = 37;
            this.gbFileDetails.TabStop = false;
            this.gbFileDetails.Text = "File details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Created:";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File path:";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Size:";
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
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "File extension:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "File name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Last accessed:";
            // 
            // gbBookDetails
            // 
            this.gbBookDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBookDetails.Controls.Add(this.btnReadEbook);
            this.gbBookDetails.Controls.Add(this.txtPrice);
            this.gbBookDetails.Controls.Add(this.label6);
            this.gbBookDetails.Controls.Add(this.label4);
            this.gbBookDetails.Controls.Add(this.label13);
            this.gbBookDetails.Controls.Add(this.label12);
            this.gbBookDetails.Controls.Add(this.dtDatePublished);
            this.gbBookDetails.Controls.Add(this.label11);
            this.gbBookDetails.Controls.Add(this.label14);
            this.gbBookDetails.Controls.Add(this.txtCategory);
            this.gbBookDetails.Controls.Add(this.dlClassification);
            this.gbBookDetails.Controls.Add(this.txtISBN);
            this.gbBookDetails.Controls.Add(this.txtTitle);
            this.gbBookDetails.Controls.Add(this.label10);
            this.gbBookDetails.Controls.Add(this.txtPublisher);
            this.gbBookDetails.Controls.Add(this.label9);
            this.gbBookDetails.Controls.Add(this.txtAuthor);
            this.gbBookDetails.Location = new System.Drawing.Point(6, 207);
            this.gbBookDetails.Name = "gbBookDetails";
            this.gbBookDetails.Size = new System.Drawing.Size(352, 273);
            this.gbBookDetails.TabIndex = 38;
            this.gbBookDetails.TabStop = false;
            this.gbBookDetails.Text = "Book details";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Author:";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Date published:";
            // 
            // dtDatePublished
            // 
            this.dtDatePublished.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDatePublished.Enabled = false;
            this.dtDatePublished.Location = new System.Drawing.Point(103, 148);
            this.dtDatePublished.Name = "dtDatePublished";
            this.dtDatePublished.Size = new System.Drawing.Size(239, 20);
            this.dtDatePublished.TabIndex = 5;
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 203);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Classification:";
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.Location = new System.Drawing.Point(103, 174);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(239, 20);
            this.txtCategory.TabIndex = 6;
            // 
            // dlClassification
            // 
            this.dlClassification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dlClassification.Enabled = false;
            this.dlClassification.FormattingEnabled = true;
            this.dlClassification.Location = new System.Drawing.Point(103, 200);
            this.dlClassification.Name = "dlClassification";
            this.dlClassification.Size = new System.Drawing.Size(239, 21);
            this.dlClassification.TabIndex = 7;
            // 
            // txtISBN
            // 
            this.txtISBN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtISBN.Location = new System.Drawing.Point(103, 122);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.ReadOnly = true;
            this.txtISBN.Size = new System.Drawing.Size(239, 20);
            this.txtISBN.TabIndex = 4;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(103, 18);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(239, 20);
            this.txtTitle.TabIndex = 0;
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
            // txtPublisher
            // 
            this.txtPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublisher.Location = new System.Drawing.Point(103, 70);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.ReadOnly = true;
            this.txtPublisher.Size = new System.Drawing.Size(239, 20);
            this.txtPublisher.TabIndex = 2;
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
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Location = new System.Drawing.Point(103, 44);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(239, 20);
            this.txtAuthor.TabIndex = 1;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(103, 96);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(239, 20);
            this.txtPrice.TabIndex = 3;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.txtStorageSpaceDescription);
            this.groupBox6.Location = new System.Drawing.Point(6, 486);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(352, 112);
            this.groupBox6.TabIndex = 39;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Virtual Storage Space Info";
            // 
            // txtStorageSpaceDescription
            // 
            this.txtStorageSpaceDescription.Location = new System.Drawing.Point(6, 19);
            this.txtStorageSpaceDescription.Multiline = true;
            this.txtStorageSpaceDescription.Name = "txtStorageSpaceDescription";
            this.txtStorageSpaceDescription.ReadOnly = true;
            this.txtStorageSpaceDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStorageSpaceDescription.Size = new System.Drawing.Size(336, 62);
            this.txtStorageSpaceDescription.TabIndex = 6;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Read eBook";
            // 
            // eBookManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 643);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "eBookManager";
            this.Text = " eBook Manager";
            this.Load += new System.EventHandler(this.eBookManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gbFileDetails.ResumeLayout(false);
            this.gbFileDetails.PerformLayout();
            this.gbBookDetails.ResumeLayout(false);
            this.gbBookDetails.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuImportEbooks;
        private System.Windows.Forms.ListView lstStorageSpaces;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstBooks;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbFileDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtLastAccessed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtCreated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbBookDetails;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtDatePublished;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.ComboBox dlClassification;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtStorageSpaceDescription;
        private System.Windows.Forms.Button btnReadEbook;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}