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
            this.CreateTaskButton = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.AssetLibraryButton = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.TaskButton = this.Factory.CreateRibbonButton();
            this.group5 = this.Factory.CreateRibbonGroup();
            this.WorkersButton = this.Factory.CreateRibbonButton();
            this.group6 = this.Factory.CreateRibbonGroup();
            this.MessageButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group3.SuspendLayout();
            this.group2.SuspendLayout();
            this.group5.SuspendLayout();
            this.group6.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group5);
            this.tab1.Groups.Add(this.group6);
            this.tab1.Label = " My Crowd ";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.CreateTaskButton);
            this.group1.Name = "group1";
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
            // group3
            // 
            this.group3.Items.Add(this.AssetLibraryButton);
            this.group3.Name = "group3";
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
            // group2
            // 
            this.group2.Items.Add(this.TaskButton);
            this.group2.Name = "group2";
            // 
            // TaskButton
            // 
            this.TaskButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.TaskButton.Image = global::DialogueBoxLauncher.Properties.Resources.tasks;
            this.TaskButton.Label = "Tasks";
            this.TaskButton.Name = "TaskButton";
            this.TaskButton.ShowImage = true;
            // 
            // group5
            // 
            this.group5.Items.Add(this.WorkersButton);
            this.group5.Name = "group5";
            // 
            // WorkersButton
            // 
            this.WorkersButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.WorkersButton.Image = global::DialogueBoxLauncher.Properties.Resources.workers;
            this.WorkersButton.Label = "Workers ";
            this.WorkersButton.Name = "WorkersButton";
            this.WorkersButton.ShowImage = true;
            // 
            // group6
            // 
            this.group6.Items.Add(this.MessageButton);
            this.group6.Name = "group6";
            // 
            // MessageButton
            // 
            this.MessageButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.MessageButton.Image = global::DialogueBoxLauncher.Properties.Resources.messages;
            this.MessageButton.Label = "Messages";
            this.MessageButton.Name = "MessageButton";
            this.MessageButton.ShowImage = true;
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
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group5.ResumeLayout(false);
            this.group5.PerformLayout();
            this.group6.ResumeLayout(false);
            this.group6.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AssetLibraryButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton CreateTaskButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton TaskButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton WorkersButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton MessageButton;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
