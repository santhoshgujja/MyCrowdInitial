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
            this.DocumentsButton = new System.Windows.Forms.Button();
            this.ImagesButton = new System.Windows.Forms.Button();
            this.ListviewData = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.SmallIconsImagelist = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.DocumentsButton);
            this.splitContainer1.Panel1.Controls.Add(this.ImagesButton);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ListviewData);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1072, 624);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 0;
            // 
            // DocumentsButton
            // 
            this.DocumentsButton.BackColor = System.Drawing.Color.DimGray;
            this.DocumentsButton.FlatAppearance.BorderSize = 0;
            this.DocumentsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DocumentsButton.ForeColor = System.Drawing.Color.White;
            this.DocumentsButton.Location = new System.Drawing.Point(0, 242);
            this.DocumentsButton.Name = "DocumentsButton";
            this.DocumentsButton.Size = new System.Drawing.Size(219, 53);
            this.DocumentsButton.TabIndex = 2;
            this.DocumentsButton.Text = "Documents ";
            this.DocumentsButton.UseVisualStyleBackColor = false;
            this.DocumentsButton.Click += new System.EventHandler(this.DocumentsButton_Click);
            // 
            // ImagesButton
            // 
            this.ImagesButton.BackColor = System.Drawing.Color.DimGray;
            this.ImagesButton.FlatAppearance.BorderSize = 0;
            this.ImagesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImagesButton.ForeColor = System.Drawing.Color.White;
            this.ImagesButton.Location = new System.Drawing.Point(0, 180);
            this.ImagesButton.Name = "ImagesButton";
            this.ImagesButton.Size = new System.Drawing.Size(219, 56);
            this.ImagesButton.TabIndex = 0;
            this.ImagesButton.Text = "Image";
            this.ImagesButton.UseVisualStyleBackColor = false;
            this.ImagesButton.Click += new System.EventHandler(this.ImagesButton_Click);
            // 
            // ListviewData
            // 
            this.ListviewData.ContextMenuStrip = this.contextMenuStrip1;
            this.ListviewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListviewData.LargeImageList = this.LargeIcons;
            this.ListviewData.Location = new System.Drawing.Point(0, 0);
            this.ListviewData.Name = "ListviewData";
            this.ListviewData.Size = new System.Drawing.Size(847, 624);
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
            this.LargeIcons.Images.SetKeyName(0, "document_final.png");
            this.LargeIcons.Images.SetKeyName(1, "Excel.png");
            this.LargeIcons.Images.SetKeyName(2, "powerpoint.png");
            this.LargeIcons.Images.SetKeyName(3, "bmp file.png");
            this.LargeIcons.Images.SetKeyName(4, "Jpg Image.png");
            this.LargeIcons.Images.SetKeyName(5, "other files.png");
            this.LargeIcons.Images.SetKeyName(6, "pdf file.png");
            this.LargeIcons.Images.SetKeyName(7, "png Image.png");
            // 
            // SmallIconsImagelist
            // 
            this.SmallIconsImagelist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallIconsImagelist.ImageStream")));
            this.SmallIconsImagelist.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallIconsImagelist.Images.SetKeyName(0, "document_final.png");
            this.SmallIconsImagelist.Images.SetKeyName(1, "Excel.png");
            this.SmallIconsImagelist.Images.SetKeyName(2, "powerpoint.png");
            this.SmallIconsImagelist.Images.SetKeyName(3, "bmp file.png");
            this.SmallIconsImagelist.Images.SetKeyName(4, "Jpg Image.png");
            this.SmallIconsImagelist.Images.SetKeyName(5, "other files.png");
            this.SmallIconsImagelist.Images.SetKeyName(6, "pdf file.png");
            this.SmallIconsImagelist.Images.SetKeyName(7, "png Image.png");
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DialogueBoxLauncher.Properties.Resources.close_form_latest2;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 36);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AssetLibraryDialogueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 624);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AssetLibraryDialogueForm";
            this.Text = "AssetLibraryDialogueForm";
            this.Load += new System.EventHandler(this.AssetLibraryDialogueForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.Button button1;
    }
}