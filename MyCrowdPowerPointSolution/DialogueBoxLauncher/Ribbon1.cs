using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace DialogueBoxLauncher
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

       public void group1_DialogLauncherClick(object sender, Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs e)
        {
            advancedSettingsDialog dlg = new advancedSettingsDialog();
            dlg.ShowDialog();
        }

       private void group2_DialogLauncherClick(object sender, RibbonControlEventArgs e)
       {
           AssetLibraryDialogueForm asdialog = new AssetLibraryDialogueForm();
           asdialog.ShowDialog();
       }

       private void TestDialogue_Click(object sender, RibbonControlEventArgs e)
       {
           AssetLibraryDialogueForm asdialog = new AssetLibraryDialogueForm();
           asdialog.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           asdialog.StartPosition = FormStartPosition.CenterScreen;

           asdialog.Show();
       }

       private void CreateTaskButton_Click(object sender, RibbonControlEventArgs e)
       {
           advancedSettingsDialog dlg = new advancedSettingsDialog();
           dlg.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           dlg.StartPosition = FormStartPosition.CenterScreen;
           dlg.Show();
       }

       private void AddNewSlideButton_Click(object sender, RibbonControlEventArgs e)
       {

       }
    }
}
