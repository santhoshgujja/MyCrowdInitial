using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.IO;

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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter =
              "All pictures (*.jpg,*.jpeg,*.bmp,*.gif,*.tif)|" +
              "*.jpf;*.jpeg;*.bmp;*.gif;*.tif|" +
              "All files (*.*)|*.*";

            dialog.CheckFileExists = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AddPicture(dialog.FileName);
            }

  
        }

        private void AddPicture(string pictureFileName)
        {
            try
            {

                PowerPoint.Presentation presentation =
                  Globals.ThisAddIn.Application.ActivePresentation;

                if (presentation != null)
                {
                    PowerPoint.Slide slide =
                      presentation.Slides.Add(
                      presentation.Slides.Count + 1,
                      PowerPoint.PpSlideLayout.ppLayoutPictureWithCaption);

                    // Shapes[2] is the image shape on this layout.
                    PowerPoint.Shape shape = slide.Shapes[2];

                    slide.Shapes.AddPicture(pictureFileName,
                      Microsoft.Office.Core.MsoTriState.msoFalse,
                      Microsoft.Office.Core.MsoTriState.msoTrue,
                      shape.Left, shape.Top, shape.Width, shape.Height);

                    // Insert the file name.
                    slide.Shapes[1].TextFrame.TextRange.Text = pictureFileName;
                    slide.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to insert selected picture: " +
                  ex.Message);
            }

        }
    
    }
}
