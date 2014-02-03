namespace DialogueBoxLauncher
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.CreateTaskButton = this.Factory.CreateRibbonButton();
            this.AssetLibraryButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group3.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Label = " My Crowd ";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.CreateTaskButton);
            this.group1.Name = "group1";
            // 
            // group3
            // 
            this.group3.Items.Add(this.AssetLibraryButton);
            this.group3.Name = "group3";
            // 
            // CreateTaskButton
            // 
            this.CreateTaskButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.CreateTaskButton.Image = global::DialogueBoxLauncher.Properties.Resources.request_task;
            this.CreateTaskButton.Label = "Request a Task";
            this.CreateTaskButton.Name = "CreateTaskButton";
            this.CreateTaskButton.ShowImage = true;
            this.CreateTaskButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.CreateTaskButton_Click);
            // 
            // AssetLibraryButton
            // 
            this.AssetLibraryButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AssetLibraryButton.Image = global::DialogueBoxLauncher.Properties.Resources.assetlib_icon;
            this.AssetLibraryButton.Label = "AssetLibrary";
            this.AssetLibraryButton.Name = "AssetLibraryButton";
            this.AssetLibraryButton.ShowImage = true;
            this.AssetLibraryButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.TestDialogue_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AssetLibraryButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton CreateTaskButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
