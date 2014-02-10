namespace DialogueBoxLauncher
{
    partial class AssetLibraryDialogueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetLibraryDialogueForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DocumentsButton = new System.Windows.Forms.Button();
            this.ImagesButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.large_afterclick = new System.Windows.Forms.Button();
            this.large_beforeclick = new System.Windows.Forms.Button();
            this.medium_afterClick = new System.Windows.Forms.Button();
            this.medium_beforeClick = new System.Windows.Forms.Button();
            this.small_afterClick = new System.Windows.Forms.Button();
            this.small_beforeclick = new System.Windows.Forms.Button();
            this.ListviewData = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.SmallIconsImagelist = new System.Windows.Forms.ImageList(this.components);
            this.Image_AfterClick = new System.Windows.Forms.Button();
            this.Documents_AfterClick = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer1.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel1.BackgroundImage")));
            this.splitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox2);
            this.splitContainer1.Panel1.Controls.Add(this.Documents_AfterClick);
            this.splitContainer1.Panel1.Controls.Add(this.Image_AfterClick);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.DocumentsButton);
            this.splitContainer1.Panel1.Controls.Add(this.ImagesButton);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel2.BackgroundImage")));
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.ListviewData);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1222, 705);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DialogueBoxLauncher.Properties.Resources.Close_final1;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 18);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // DocumentsButton
            // 
            this.DocumentsButton.BackColor = System.Drawing.Color.DimGray;
            this.DocumentsButton.FlatAppearance.BorderSize = 0;
            this.DocumentsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DocumentsButton.ForeColor = System.Drawing.Color.White;
            this.DocumentsButton.Image = ((System.Drawing.Image)(resources.GetObject("DocumentsButton.Image")));
            this.DocumentsButton.Location = new System.Drawing.Point(55, 281);
            this.DocumentsButton.Name = "DocumentsButton";
            this.DocumentsButton.Size = new System.Drawing.Size(235, 50);
            this.DocumentsButton.TabIndex = 2;
            this.DocumentsButton.UseVisualStyleBackColor = false;
            this.DocumentsButton.Click += new System.EventHandler(this.DocumentsButton_Click);
            // 
            // ImagesButton
            // 
            this.ImagesButton.BackColor = System.Drawing.Color.Gray;
            this.ImagesButton.FlatAppearance.BorderSize = 0;
            this.ImagesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImagesButton.ForeColor = System.Drawing.Color.DimGray;
            this.ImagesButton.Image = ((System.Drawing.Image)(resources.GetObject("ImagesButton.Image")));
            this.ImagesButton.Location = new System.Drawing.Point(55, 222);
            this.ImagesButton.Name = "ImagesButton";
            this.ImagesButton.Size = new System.Drawing.Size(235, 50);
            this.ImagesButton.TabIndex = 0;
            this.ImagesButton.UseVisualStyleBackColor = false;
            this.ImagesButton.Click += new System.EventHandler(this.ImagesButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.large_afterclick);
            this.panel1.Controls.Add(this.large_beforeclick);
            this.panel1.Controls.Add(this.medium_afterClick);
            this.panel1.Controls.Add(this.medium_beforeClick);
            this.panel1.Controls.Add(this.small_afterClick);
            this.panel1.Controls.Add(this.small_beforeclick);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 50);
            this.panel1.TabIndex = 1;
            // 
            // large_afterclick
            // 
            this.large_afterclick.FlatAppearance.BorderSize = 0;
            this.large_afterclick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.large_afterclick.Image = ((System.Drawing.Image)(resources.GetObject("large_afterclick.Image")));
            this.large_afterclick.Location = new System.Drawing.Point(867, 12);
            this.large_afterclick.Name = "large_afterclick";
            this.large_afterclick.Size = new System.Drawing.Size(26, 26);
            this.large_afterclick.TabIndex = 5;
            this.large_afterclick.UseVisualStyleBackColor = true;
            // 
            // large_beforeclick
            // 
            this.large_beforeclick.FlatAppearance.BorderSize = 0;
            this.large_beforeclick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.large_beforeclick.Image = ((System.Drawing.Image)(resources.GetObject("large_beforeclick.Image")));
            this.large_beforeclick.Location = new System.Drawing.Point(872, 19);
            this.large_beforeclick.Name = "large_beforeclick";
            this.large_beforeclick.Size = new System.Drawing.Size(17, 17);
            this.large_beforeclick.TabIndex = 4;
            this.large_beforeclick.UseVisualStyleBackColor = true;
            this.large_beforeclick.Click += new System.EventHandler(this.large_beforeclick_Click);
            // 
            // medium_afterClick
            // 
            this.medium_afterClick.FlatAppearance.BorderSize = 0;
            this.medium_afterClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.medium_afterClick.Image = ((System.Drawing.Image)(resources.GetObject("medium_afterClick.Image")));
            this.medium_afterClick.Location = new System.Drawing.Point(823, 12);
            this.medium_afterClick.Name = "medium_afterClick";
            this.medium_afterClick.Size = new System.Drawing.Size(26, 26);
            this.medium_afterClick.TabIndex = 3;
            this.medium_afterClick.UseVisualStyleBackColor = true;
            // 
            // medium_beforeClick
            // 
            this.medium_beforeClick.FlatAppearance.BorderSize = 0;
            this.medium_beforeClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.medium_beforeClick.Image = ((System.Drawing.Image)(resources.GetObject("medium_beforeClick.Image")));
            this.medium_beforeClick.Location = new System.Drawing.Point(829, 19);
            this.medium_beforeClick.Name = "medium_beforeClick";
            this.medium_beforeClick.Size = new System.Drawing.Size(17, 17);
            this.medium_beforeClick.TabIndex = 2;
            this.medium_beforeClick.UseVisualStyleBackColor = true;
            this.medium_beforeClick.Click += new System.EventHandler(this.medium_beforeClick_Click);
            // 
            // small_afterClick
            // 
            this.small_afterClick.FlatAppearance.BorderSize = 0;
            this.small_afterClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.small_afterClick.Image = ((System.Drawing.Image)(resources.GetObject("small_afterClick.Image")));
            this.small_afterClick.Location = new System.Drawing.Point(780, 12);
            this.small_afterClick.Name = "small_afterClick";
            this.small_afterClick.Size = new System.Drawing.Size(26, 26);
            this.small_afterClick.TabIndex = 1;
            this.small_afterClick.UseVisualStyleBackColor = true;
            // 
            // small_beforeclick
            // 
            this.small_beforeclick.FlatAppearance.BorderSize = 0;
            this.small_beforeclick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.small_beforeclick.Image = ((System.Drawing.Image)(resources.GetObject("small_beforeclick.Image")));
            this.small_beforeclick.Location = new System.Drawing.Point(785, 19);
            this.small_beforeclick.Name = "small_beforeclick";
            this.small_beforeclick.Size = new System.Drawing.Size(17, 17);
            this.small_beforeclick.TabIndex = 0;
            this.small_beforeclick.UseVisualStyleBackColor = true;
            this.small_beforeclick.Click += new System.EventHandler(this.small_beforeclick_Click);
            // 
            // ListviewData
            // 
            this.ListviewData.BackColor = System.Drawing.Color.White;
            this.ListviewData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListviewData.ContextMenuStrip = this.contextMenuStrip1;
            this.ListviewData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListviewData.LargeImageList = this.LargeIcons;
            this.ListviewData.Location = new System.Drawing.Point(0, 44);
            this.ListviewData.Name = "ListviewData";
            this.ListviewData.Size = new System.Drawing.Size(904, 661);
            this.ListviewData.SmallImageList = this.SmallIconsImagelist;
            this.ListviewData.TabIndex = 0;
            this.ListviewData.UseCompatibleStateImageBehavior = false;
            this.ListviewData.DoubleClick += new System.EventHandler(this.ListviewData_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.listViewToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.viewToolStripMenuItem.Text = "view";
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.largeIconsToolStripMenuItem.Text = "Large Icons";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.largeIconsToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.smallIconsToolStripMenuItem.Text = "Small Icons";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.smallIconsToolStripMenuItem_Click);
            // 
            // listViewToolStripMenuItem
            // 
            this.listViewToolStripMenuItem.Name = "listViewToolStripMenuItem";
            this.listViewToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.listViewToolStripMenuItem.Text = "List View";
            this.listViewToolStripMenuItem.Click += new System.EventHandler(this.listViewToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // LargeIcons
            // 
            this.LargeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LargeIcons.ImageStream")));
            this.LargeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.LargeIcons.Images.SetKeyName(0, "other files.png");
            this.LargeIcons.Images.SetKeyName(1, "application.png");
            this.LargeIcons.Images.SetKeyName(2, "audio.png");
            this.LargeIcons.Images.SetKeyName(3, "doc.png");
            this.LargeIcons.Images.SetKeyName(4, "docx.png");
            this.LargeIcons.Images.SetKeyName(5, "gzip.png");
            this.LargeIcons.Images.SetKeyName(6, "html.png");
            this.LargeIcons.Images.SetKeyName(7, "image.png");
            this.LargeIcons.Images.SetKeyName(8, "mp3.png");
            this.LargeIcons.Images.SetKeyName(9, "pdf.png");
            this.LargeIcons.Images.SetKeyName(10, "ppt.png");
            this.LargeIcons.Images.SetKeyName(11, "pptx.png");
            this.LargeIcons.Images.SetKeyName(12, "psd.png");
            this.LargeIcons.Images.SetKeyName(13, "text.png");
            this.LargeIcons.Images.SetKeyName(14, "video.png");
            this.LargeIcons.Images.SetKeyName(15, "xls.png");
            this.LargeIcons.Images.SetKeyName(16, "xlsx.png");
            this.LargeIcons.Images.SetKeyName(17, "zip.png");
            // 
            // SmallIconsImagelist
            // 
            this.SmallIconsImagelist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallIconsImagelist.ImageStream")));
            this.SmallIconsImagelist.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallIconsImagelist.Images.SetKeyName(0, "other files.png");
            this.SmallIconsImagelist.Images.SetKeyName(1, "application.png");
            this.SmallIconsImagelist.Images.SetKeyName(2, "audio.png");
            this.SmallIconsImagelist.Images.SetKeyName(3, "doc.png");
            this.SmallIconsImagelist.Images.SetKeyName(4, "docx.png");
            this.SmallIconsImagelist.Images.SetKeyName(5, "gzip.png");
            this.SmallIconsImagelist.Images.SetKeyName(6, "html.png");
            this.SmallIconsImagelist.Images.SetKeyName(7, "image.png");
            this.SmallIconsImagelist.Images.SetKeyName(8, "mp3.png");
            this.SmallIconsImagelist.Images.SetKeyName(9, "pdf.png");
            this.SmallIconsImagelist.Images.SetKeyName(10, "ppt.png");
            this.SmallIconsImagelist.Images.SetKeyName(11, "pptx.png");
            this.SmallIconsImagelist.Images.SetKeyName(12, "psd.png");
            this.SmallIconsImagelist.Images.SetKeyName(13, "text.png");
            this.SmallIconsImagelist.Images.SetKeyName(14, "video.png");
            this.SmallIconsImagelist.Images.SetKeyName(15, "xls.png");
            this.SmallIconsImagelist.Images.SetKeyName(16, "xlsx.png");
            this.SmallIconsImagelist.Images.SetKeyName(17, "zip.png");
            // 
            // Image_AfterClick
            // 
            this.Image_AfterClick.BackColor = System.Drawing.Color.White;
            this.Image_AfterClick.FlatAppearance.BorderSize = 0;
            this.Image_AfterClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Image_AfterClick.Image = ((System.Drawing.Image)(resources.GetObject("Image_AfterClick.Image")));
            this.Image_AfterClick.Location = new System.Drawing.Point(51, 222);
            this.Image_AfterClick.Name = "Image_AfterClick";
            this.Image_AfterClick.Size = new System.Drawing.Size(249, 50);
            this.Image_AfterClick.TabIndex = 4;
            this.Image_AfterClick.UseVisualStyleBackColor = false;
            // 
            // Documents_AfterClick
            // 
            this.Documents_AfterClick.BackColor = System.Drawing.Color.White;
            this.Documents_AfterClick.FlatAppearance.BorderSize = 0;
            this.Documents_AfterClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Documents_AfterClick.Image = ((System.Drawing.Image)(resources.GetObject("Documents_AfterClick.Image")));
            this.Documents_AfterClick.Location = new System.Drawing.Point(51, 281);
            this.Documents_AfterClick.Name = "Documents_AfterClick";
            this.Documents_AfterClick.Size = new System.Drawing.Size(253, 50);
            this.Documents_AfterClick.TabIndex = 6;
            this.Documents_AfterClick.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(55, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(235, 50);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // AssetLibraryDialogueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1222, 705);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AssetLibraryDialogueForm";
            this.Text = "AssetLibraryDialogueForm";
            this.Load += new System.EventHandler(this.AssetLibraryDialogueForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button DocumentsButton;
        private System.Windows.Forms.Button ImagesButton;
        private System.Windows.Forms.ListView ListviewData;
        private System.Windows.Forms.ImageList LargeIcons;
        private System.Windows.Forms.ImageList SmallIconsImagelist;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button medium_afterClick;
        private System.Windows.Forms.Button medium_beforeClick;
        private System.Windows.Forms.Button small_afterClick;
        private System.Windows.Forms.Button small_beforeclick;
        private System.Windows.Forms.Button large_afterclick;
        private System.Windows.Forms.Button large_beforeclick;
        private System.Windows.Forms.Button Documents_AfterClick;
        private System.Windows.Forms.Button Image_AfterClick;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}