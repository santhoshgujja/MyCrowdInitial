using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace PowerPointAddIn2
{
    public partial class RibbonTest
    {
        PowerPoint.CustomLayout customLayout = null;
        PowerPoint.Slide newSlide = null;
        private void RibbonTest_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            int count = Globals.ThisAddIn.Application.ActivePresentation.Slides.Count;

            customLayout = Globals.ThisAddIn.Application.ActivePresentation.SlideMaster.CustomLayouts[5];
            if (count == 0)
            {
                newSlide = Globals.ThisAddIn.Application.ActivePresentation.Slides.AddSlide(1, customLayout);
            }
            else
            {
                newSlide = Globals.ThisAddIn.Application.ActivePresentation.Slides.AddSlide(count + 1, customLayout);
            }
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            

            int count = Globals.ThisAddIn.Application.ActivePresentation.Slides.Count;
            if (count > 0)
            {
                Globals.ThisAddIn.Application.ActivePresentation.Slides[count].Delete();
            }
   
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            OpenFileDialog openFileDialogue1 = new OpenFileDialog();
            openFileDialogue1.Multiselect = false;
            openFileDialogue1.DefaultExt = ".png";
           // openFileDialogue1.OpenFile();


            if (openFileDialogue1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePaths = openFileDialogue1.FileName;
                
            }
            //List<string> filesList = filePathsList.ToList<string>();
            //foreach (string filepath in filesList)
            //{
            //    AddFilesPathsList.AppendText(filepath + "\n");
            //}
        }
       
    }
}
