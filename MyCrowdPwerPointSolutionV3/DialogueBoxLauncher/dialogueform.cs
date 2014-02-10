using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//RestSharp
using RestSharp;
using RestSharp.Serializers;

// add PowerPoint namespace 
using PPt = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;
//using Newtonsoft.Json;

//Add TaskObject
using Mycrowd.Task.Model;
using System.Text.RegularExpressions;

namespace DialogueBoxLauncher
{
    public partial class advancedSettingsDialog : Form
    {
        string tempfilePath = System.IO.Path.GetTempPath();
        string uploadPPtfile;
        bool assetsAvailable = false;
        bool publishWithemptyDescTask = false;
        bool publishWithoutConfirm = false;
        bool publishWithOutPrice = false;

        public advancedSettingsDialog()
        {
            
            InitializeComponent();
            PerformInitialSettings();
            CheckPowerpointrunning();
            splitContainer1.SplitterDistance = taskCategory.Size.Width + 3;
        }

        private void PerformInitialSettings()
        {
            AddFilesComboBox.Visible = false;
            HideAddFilesTextAndLabels();
            TaskNameLabel.Visible = false;
            slidesValidation.Visible = false;
            if (TotalSlides() == 0)
            {
                AddFilesPPRadioButton.Visible = false;
            }
            else
            {
                AddFilesPPRadioButton.Visible = true;
            }

        }

        #region DIALOGUE CODE

        private void advancedSettingsDialog_Load(object sender, EventArgs e)
        {
            ValidateTasks();
            HideAllPanels();
            HideAddFilesTextAndLabels();
            TaskCategoryPanel.Visible = true;
        }

        private void DescribeTask_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            DescribeTheTaskPanel.Visible = true;
        }

        private void taskCategory_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            TaskCategoryPanel.Visible = true;
        }

        private void AddFiles_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            AddFilesPanel.Visible = true;
            if (TotalSlides() == 0)
            {
                AddFilesPPRadioButton.Visible = false;
            }
            else
            {
                AddFilesPPRadioButton.Visible = true;
            }

        }

        private void SetThePrice_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            SetaPricePanel.Visible = true;

        }

        private void HideAllPanels() 
        {
            TaskCategoryPanel.Visible = false;
            DescribeTheTaskPanel.Visible = false;
            AddFilesPanel.Visible = false;
            ConfirmPanel.Visible = false;
            FindaWorkerPanel.Visible = false;
            SetaPricePanel.Visible = false;
        }

        private void FindaWorker_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            FindaWorkerPanel.Visible = true;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            ConfirmPanel.Visible = true;
        }

        private void FindaWorkerNext_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            ConfirmPanel.Visible = true;
        }

        private void FindaWorkerPrevious_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            SetaPricePanel.Visible = true;
        }

        private void SetaPriceNext_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            FindaWorkerPanel.Visible = true;
        }

        private void SetaPricePrevious_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            AddFilesPanel.Visible = true;
            if (TotalSlides() == 0)
            {
                AddFilesPPRadioButton.Visible = false;
            }
            else
            {
                AddFilesPPRadioButton.Visible = true;
            }
        }

        private void AddFilesNext_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            bool pptResult = ValidatePPTs();

            if (pptResult)
            {
                slidesValidation.Visible = false;
                SetaPricePanel.Visible = true;
            }
            else
            {
                AddFilesPanel.Visible = true;
            }
        }

        private bool ValidatePPTs()
        {
            if (AddFilesPPRadioButton.Checked == true && AddFilesComboBox.SelectedIndex == 1)
            {
                Int64 output;
                bool validMInValue = Int64.TryParse(AddFilesFromTextbox.Text, out output);

                if (string.IsNullOrWhiteSpace(AddFilesFromTextbox.Text.ToString()))
                {

                    slidesValidation.Text = "Please select valid slide Range";
                    slidesValidation.Visible = true;
                    return false;

                }
                else if (!validMInValue)
                {
                    slidesValidation.Text = "Please select valid Num in Min Slide Num.";
                    slidesValidation.Visible = true;
                    return false;
                }
                else if (int.Parse(AddFilesFromTextbox.Text.ToString()) == 0)
                {
                    slidesValidation.Text = "Please select valid slide Range.Slide Number starts from 1.";
                    slidesValidation.Visible = true;
                    return false;
                }

                Int64 maxSlideNum;
                bool validMaxValue = Int64.TryParse(AddFilesToTextbox.Text, out maxSlideNum);
                if (string.IsNullOrWhiteSpace(AddFilesToTextbox.Text.ToString()))
                {
                    slidesValidation.Text = "Please select valid slide Range.";
                    slidesValidation.Visible = true;
                    return false;
                }
                else if (!validMaxValue)
                {
                    slidesValidation.Text = "Please Enter Number in the Max Slide Number";
                    slidesValidation.Visible = true;
                    return false;
                }
                else if (int.Parse(AddFilesToTextbox.Text.ToString()) > TotalSlides())
                {
                    slidesValidation.Text = "The Max slide Num should be less than Total Slides";
                    slidesValidation.Visible = true;
                    return false;
                }
            }

            return true;
        }

        private void AddFilesPrevious_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            bool pptResult = ValidatePPTs();

            if (pptResult)
            {
                slidesValidation.Visible = false;
                DescribeTheTaskPanel.Visible = true;
            }
            else
            {
                AddFilesPanel.Visible = true;
            }
            
        }

        private void DescribeTaskNext_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            AddFilesPanel.Visible = true;
            if (TotalSlides() == 0)
            {
                AddFilesPPRadioButton.Visible = false;
            }
            else
            {
                AddFilesPPRadioButton.Visible = true;
            }
        }

        private void DescribeTaskPrevious_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            TaskCategoryPanel.Visible = true;
        }

        private void TaskCategoryNext_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            DescribeTheTaskPanel.Visible = true;
        }

        public string[] filePathsList;

        private void AddFilesUploadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogue1 = new OpenFileDialog();
            openFileDialogue1.Multiselect = true;
            AddFilesPathsList.Text = "";

            if (openFileDialogue1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePathsList = openFileDialogue1.FileNames;
            }
            List<string> filesList = filePathsList.ToList<string>();
            foreach (string filepath in filesList)
            {
                AddFilesPathsList.AppendText(filepath + "\n");
            }



        }

        private void SetapricePrevious_Click_1(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            AddFilesPanel.Visible = true;
        }

        private void AddFilesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AddFilesComboBox.SelectedIndex == 1)
            {
                AddFilesFromlabel.Visible = true;
                AddFilesFromTextbox.Visible = true;
                AddFilesToLabel.Visible = true;
                AddFilesToTextbox.Visible = true;
            }
            else
            {
                HideAddFilesTextAndLabels();
            }
        }

        private void HideAddFilesTextAndLabels()
        {
            AddFilesFromlabel.Visible = false;
            AddFilesFromTextbox.Visible = false;
            AddFilesToLabel.Visible = false;
            AddFilesToTextbox.Visible = false;
        }

        public void ValidateTasks() 
        {


            taskCategory.BackColor = (radioButton1.Checked || radioButton2.Checked ||
                                        radioButton3.Checked || radioButton4.Checked) ? Color.LightGreen :
                                                  (taskCategory.BackColor != Color.Red)?Color.DimGray: Color.Red;

            DescribeTask.BackColor = (!string.IsNullOrEmpty(taskDescriptionText.Text.ToString())) ? Color.LightGreen :
                                                                (DescribeTask.BackColor != Color.Red)?Color.DimGray:Color.Red;

            FindaWorker.BackColor = (FindaWorkerRadio2.Checked || FindaWorkerRadio3.Checked) ? Color.LightGreen :
                                                        (FindaWorker.BackColor != Color.Red) ? Color.DimGray : Color.Red;


            Confirm.BackColor = (ConfirmCheckBox.Checked) ? Color.LightGreen :
                                (Confirm.BackColor != Color.Red) ? Color.DimGray : Color.Red;
        
        }

       
#endregion
        private void ConfirmPublishTask_Click(object sender, EventArgs e)
        {
           

            bool isSuccessfull = true;
            StringBuilder message = new StringBuilder();
            //Perform Validations
            if (string.IsNullOrWhiteSpace(TaskNameTextBox.Text.ToString()))
            {
                HideAllPanels();
                ValidateTasks();
                TaskNameLabel.Visible = true;
                isSuccessfull = false;
            }

            if (taskCategory.BackColor != Color.LightGreen)
            {
                HideAllPanels();
                ValidateTasks();
                taskCategory.BackColor = Color.Red;
                isSuccessfull = false;
            }


            if (DescribeTask.BackColor != Color.LightGreen)
            {
                HideAllPanels();
                ValidateTasks();
                DescribeTask.BackColor = Color.Red;
                publishWithemptyDescTask = true;
                isSuccessfull = false;
            }

            if (SetThePrice.BackColor != Color.LightGreen)
            {
                HideAllPanels();
                ValidateTasks();
                SetThePrice.BackColor = Color.Red;
                publishWithOutPrice = true;
                isSuccessfull = false;
            }

            if (FindaWorker.BackColor != Color.LightGreen)
            {
                HideAllPanels();
                ValidateTasks();
                FindaWorker.BackColor = Color.Red;
                isSuccessfull = false;
            }

            if (!ConfirmCheckBox.Checked)
            {
                HideAllPanels();
                ValidateTasks();
                Confirm.BackColor = Color.Red;
                publishWithoutConfirm = true;
                isSuccessfull = false;
            }


            if (isSuccessfull == false)
            {
                if (taskCategory.BackColor == Color.Red)
                {
                    TaskCategoryPanel.Visible = true;
                }
                else if (DescribeTask.BackColor == Color.Red)
                {
                    DescribeTheTaskPanel.Visible = true;
                }
                else if (SetThePrice.BackColor == Color.Red)
                {
                    SetaPricePanel.Visible = true;
                }
                else if (FindaWorker.BackColor == Color.Red)
                {
                    FindaWorkerPanel.Visible = true;
                }
                else if(Confirm.BackColor == Color.Red)
                {
                    ConfirmPanel.Visible = true;
                }

            }
            else
            {
                //Post a task
                MessageBox.Show("The Task has been Successfully posted to Your MyCrowd");
                if (AddFilesPPRadioButton.Checked)
                {
                    saveslidestoComputer();
                }
                PostTaskFinal();
            }
   
           
        }

        #region publishing Task

        private void PostTaskFinal()
        {
           

            //UploadFiles
            List<string> uploadFileKeyslist = UploadFiles();
           
            string password = GetSignInPassword();
            Task task = GetTaskData(uploadFileKeyslist);

            string response = UploadTaskData(task, password);

        }

        private List<string> UploadFiles()
        {
             var client = new RestClient("https://staging.mycrowd.com/api/upload");
             var requestRest = new RestRequest(Method.POST);
             requestRest.AddHeader("content-type", "application/json");
             List<string> responseFileList = new List<string>();
                

            //Get the list  of files from Upload Text box
            string uploadfileslist = AddFilesPathsList.Text;
            string[] fileslist = null;
            if (!string.IsNullOrWhiteSpace(uploadfileslist))
            {
                fileslist = uploadfileslist.Split('\n');
            }
            if (filePathsList != null)
            {

                foreach (string filepath in filePathsList)
                {
                    if(!string.IsNullOrWhiteSpace(filepath))
                    {
                        requestRest.AddFile("FilesUploadedFromPPt",filepath);
                        requestRest.RequestFormat = DataFormat.Json;
                        var restResponse = client.Execute(requestRest);
                        var UploadResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UploadResponse>(restResponse.Content);
                          responseFileList.Add(UploadResponse.key);
                    }
                }
            }

            //Get ppt file key aswell if it is checked
            //uploadPPtfile
            if (AddFilesPPRadioButton.Checked)
            {
                requestRest.AddFile("PPTSlides", uploadPPtfile);
                requestRest.RequestFormat = DataFormat.Json;
                var restResponse = client.Execute(requestRest);
                var UploadResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<UploadResponse>(restResponse.Content);
                responseFileList.Add(UploadResponse.key);
            }

            if (responseFileList.Count > 0)
                assetsAvailable = true;
            else
                assetsAvailable = false;

            return responseFileList;
            //Get the key and add it to List<string>
            //return the list.

           
        }

        private string UploadTaskData(Task task, string password)
        {
            var clientPostTask = new RestClient("https://mycrowd-dev.herokuapp.com/api/tasks");
            var clientrequestRest = new RestRequest(Method.POST);
            clientrequestRest.AddHeader("Content-Type", "application/json");
            clientrequestRest.AddHeader("X-Auth-User", "powerpoint@mycrowd.com");
            clientrequestRest.AddHeader("X-Auth-Token", password);
            clientrequestRest.JsonSerializer = new CustomJsonSerializer();
            clientrequestRest.RequestFormat = DataFormat.Json;
            clientrequestRest.AddBody(task);
            var clientTaskResponse = clientPostTask.Execute(clientrequestRest);
            return clientTaskResponse.StatusDescription;
        }

        private Task GetTaskData(List<string> uploadFileKeyslist)
        {

            Task task = new Task();
            task.Title = TaskNameTextBox.Text.ToString();
            task.JobType = (radioButton1.Checked) ? "design" :
                           (radioButton2.Checked) ? "web_development" :
                           (radioButton3.Checked) ? "writing" :
                                                    "research";
            task.Description = taskDescriptionText.Text.ToString();
            task.Visibility = "invite_only";
            task.TeamId = null;
            
            TermsAttributes terms_attributes = new TermsAttributes()
                                                        {
                                                            PaymentType = "fixed_price",
                                                            Budget = SetaPricePriceValue.Value.ToString(),
                                                            Duration="less_than_one_week"
                                                        };
            task.TermsAttributes = terms_attributes;
            task.AssetCollectionAttributes = GetAssetCollectionAttributes(uploadFileKeyslist);

            
            #region Asset Collection Later
            //AssetCollectionAttributes asset_collection_attributes = new AssetCollectionAttributes();
            //List<AssetsAttribute> assetattributescolletion = new List<AssetsAttribute>();
            //for(int i = 0; i < 1; i++)
            //{
            //    AssetsAttribute asset_attribute = new AssetsAttribute()
            //                                                {
            //                                                    AssetTypeName = "webpage",
            //                                                    ContentType = "image/png",
            //                                                    Description ="powerpoint test",
            //                                                    Height = 929,
            //                                                    LookupKey = "screens/aad72d77-4179-4ec7-b856-a9f6a2d8bbcf.png",
            //                                                    Name = "screens/aad72d77-4179-4ec7-b856-a9f6a2d8bbcf.png",
            //                                                    Url ="https://www.engineyard.com",
            //                                                    Width=937
            //                                                };
            //    assetattributescolletion.Add(asset_attribute);
                
            //}
            // asset_collection_attributes.AssetsAttributes = assetattributescolletion.ToArray();  
            //task.AssetCollectionAttributes = asset_collection_attributes;
#endregion

            
           

             return task;
        }

        private AssetCollectionAttributes GetAssetCollectionAttributes(List<string> uploadFileKeyslist)
        {

            List<AssetsAttribute> assetattributescolletion = new List<AssetsAttribute>();

            if (uploadFileKeyslist != null && uploadFileKeyslist.Count > 0)
            {
                foreach (string uploadfileKey in uploadFileKeyslist)
                {
                    if (!string.IsNullOrWhiteSpace(uploadfileKey))
                    {
                        AssetsAttribute asset_attribute = new AssetsAttribute()
                        {
                            AssetTypeName = "webpage",
                            Name = uploadfileKey,
                            Url = "NotNull",
                            ContentType = "",
                            Description = "Asset file Uploaded From PPT.",
                            Height = 540,
                            LookupKey = uploadfileKey,
                            Width = 540

                        };
                        assetattributescolletion.Add(asset_attribute);
                    }
                }

            }
            else
            {
               
                    AssetsAttribute asset_attribute = new AssetsAttribute()
                                                                {
                                                                    AssetTypeName = "webpage",
                                                                    Name = "Test",
                                                                    Url = "NotNull",
                                                                    ContentType = "",
                                                                    Description = "",
                                                                    Height = 1,
                                                                    LookupKey = "",
                                                                    Width = 1

                                                                };
                    assetattributescolletion.Add(asset_attribute);

                
            }
            return new AssetCollectionAttributes()
            {
                AssetsAttributes = assetattributescolletion.ToArray()
            };
        }

        private string GetSignInPassword()
        {
            SignInRequest request = new SignInRequest();
            request.username = "powerpoint@mycrowd.com";
            request.password = "p0w3rp01nt";
            request.remember_me = false;

            var client = new RestClient("https://mycrowd-dev.herokuapp.com/api/users/sign_in");
            var requestRest = new RestRequest(Method.POST);
            requestRest.AddHeader("content-type", "application/json");
            requestRest.JsonSerializer = new CustomJsonSerializer();
            requestRest.RequestFormat = DataFormat.Json;
            requestRest.AddBody(request);
            var restResponse = client.Execute(requestRest);

            var signInResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<SignInResponse>(restResponse.Content);
            string password = signInResponse.auth_token;

            return password;
        }
        #endregion

        #region POWERPOINT CODE
        PPt.Application pptApplication;
        PPt.Slides slides;
        PPt.Slide slide;
        PPt.Presentation presentation;

        private void CheckPowerpointrunning()
        {
            // Get Running PowerPoint Application object 
          pptApplication = Marshal.GetActiveObject("PowerPoint.Application") as PPt.Application;
          if (pptApplication != null)
          {
              presentation = pptApplication.ActivePresentation;
              slides = presentation.Slides;
              var slidescount = slides.Count;
              // Get current selected slide  
              try
              {
                  // Get selected slide object in normal view 
                   slide = slides[pptApplication.ActiveWindow.Selection.SlideRange.SlideNumber];
              }
              catch
              {
                 // slide = pptApplication.SlideShowWindows[1].View.Slide;
              }
          } 

        }

        private PPt.Slide FirstSlide()
        {
            try
            {
                // Call Select method to select first slide in normal view 
                slides[1].Select();
                slide = slides[1];
            }
            catch
            {
                // Transform to first page in reading view 
                pptApplication.SlideShowWindows[1].View.First();
                slide = pptApplication.SlideShowWindows[1].View.Slide;
            }

            return slide;

        }

        private void saveslidestoComputer()
        {
           
            if (AddFilesPPRadioButton.Checked && AddFilesComboBox.SelectedIndex == 1)
            { 
                int min = int.Parse(AddFilesFromTextbox.Text.ToString());
                int max = int.Parse(AddFilesToTextbox.Text.ToString());
                RemoveUnnecessarySlides(min,max);
            }
            uploadPPtfile = tempfilePath + "PPTFilesUploaded.PPTX";
            presentation.SaveCopyAs(uploadPPtfile);
           
        }

        private void RemoveUnnecessarySlides(int min,int max)
        {
            for (int i = 1; i <= TotalSlides(); i++)
            {
                if (i < min || i > max)
                {
                    presentation.Slides[i].Delete();
                }
            }
        }

        private int TotalSlides()
        {
            if (slides != null)
                return slides.Count;
            else
                return 0;
        }

        #endregion

        #region Validations2

        private void AddFilesToTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ConfirmCheckBox.Checked)
            {
                Confirm.BackColor = Color.LightGreen;
            }
            else
            {
                if (publishWithoutConfirm)
                { 
                    Confirm.BackColor = Color.Red; 
                }
                else
                {
                    Confirm.BackColor = Color.DimGray;
                }

            }
        }

        private void ConfirmCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmSaveDraft_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your task has been Saved. It will be added to your Task List.");
        }

        private void AddFilesPathsList_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddFilesPathsList.Text.ToString()))
            {
                AddFiles.BackColor = Color.LightGreen;
            }
            else
            {
                AddFiles.BackColor = Color.LightGray;
            }
        }

        #endregion

        private void TaskCategory_radiobutton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked)
            {
                taskCategory.BackColor = Color.LightGreen;
            }

            if (radioButton1.Checked)
            {
                radioButton1.BackColor = Color.DarkSeaGreen;
                radioButton2.BackColor = Color.White;
                radioButton3.BackColor = Color.White;
                radioButton4.BackColor = Color.White;
            }
            else if (radioButton2.Checked)
            {
                radioButton1.BackColor = Color.White;
                radioButton2.BackColor = Color.DarkSeaGreen;
                radioButton3.BackColor = Color.White;
                radioButton4.BackColor = Color.White;
            }
            else if (radioButton3.Checked)
            {
                radioButton1.BackColor = Color.White; 
                radioButton2.BackColor = Color.White; 
                radioButton3.BackColor = Color.DarkSeaGreen;
                radioButton4.BackColor = Color.White;
            }
            else if (radioButton4.Checked)
            {
                radioButton1.BackColor = Color.White;
                radioButton2.BackColor = Color.White;
                radioButton3.BackColor = Color.White;
                radioButton4.BackColor = Color.DarkSeaGreen; 
            }

        }

        private void FindaWorker_radioButton_Click(object sender, EventArgs e)
        {
            if (FindaWorkerRadio2.Checked || FindaWorkerRadio3.Checked)
            {
                FindaWorker.BackColor = Color.LightGreen;
            }
            else
            {
                if (FindaWorker.BackColor != Color.Red)
                {
                    FindaWorker.BackColor = Color.DimGray;
                }
            }
            
        }

        private void taskDescriptionText_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(taskDescriptionText.Text.ToString()))
            {
                DescribeTask.BackColor = Color.LightGreen;
            }
            else
            {
                if (publishWithemptyDescTask)
                {
                    DescribeTask.BackColor = Color.Red;
                }
                else
                {
                    DescribeTask.BackColor = Color.DimGray;
                }
            }
        }

        private void SetaPricePriceValue_ValueChanged(object sender, EventArgs e)
        {
            if (SetaPricePriceValue.Value == decimal.Zero)
            {
                if (!publishWithOutPrice)
                {
                    SetThePrice.BackColor = Color.DimGray;
                }
                else
                {
                    SetThePrice.BackColor = Color.Red;
                }
            }
            else
            {
                SetThePrice.BackColor = Color.LightGreen;
            }
        }

        #region MOUSE EVENTS.

        private void radioButton1_MouseHover(object sender, EventArgs e)
        {
            radioButton1.BackColor = Color.LightSkyBlue;
        }

        private void radioButton1_MouseLeave(object sender, EventArgs e)
        {
            if(!radioButton1.Checked)
            radioButton1.BackColor = Color.White;
        }

        private void radioButton1_MouseEnter(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            radioButton1.BackColor = Color.LightSkyBlue;
        }

        private void radioButton2_MouseEnter(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)
            radioButton2.BackColor = Color.LightSkyBlue;
        }

        private void radioButton2_MouseLeave(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)
            radioButton2.BackColor = Color.White;
        }

        private void radioButton3_MouseEnter(object sender, EventArgs e)
        {
            if (!radioButton3.Checked)
            radioButton3.BackColor = Color.LightSkyBlue;
        }

        private void radioButton3_MouseLeave(object sender, EventArgs e)
        {
            if (!radioButton3.Checked)
            radioButton3.BackColor = Color.White;
        }

        private void radioButton4_MouseEnter(object sender, EventArgs e)
        {
            if (!radioButton4.Checked)
            radioButton4.BackColor = Color.LightSkyBlue;
        }

        private void radioButton4_MouseLeave(object sender, EventArgs e)
        {
            if (!radioButton4.Checked)
            radioButton4.BackColor = Color.White;
        }

        private void FindaWorkerRadio2_MouseEnter(object sender, EventArgs e)
        {
            FindaWorkerRadio2.BackColor = Color.LightSkyBlue;
        }

        private void FindaWorkerRadio2_MouseLeave(object sender, EventArgs e)
        {
            FindaWorkerRadio2.BackColor = Color.White;
        }

        private void FindaWorkerRadio3_MouseEnter(object sender, EventArgs e)
        {
            FindaWorkerRadio3.BackColor = Color.LightSkyBlue;
        }

        private void FindaWorkerRadio3_MouseLeave(object sender, EventArgs e)
        {
            FindaWorkerRadio3.BackColor = Color.White;
        }


        #endregion

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
                  //ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
            //                            Color.White, 0, ButtonBorderStyle.Solid,
            //                            Color.White, 0, ButtonBorderStyle.Solid,
            //                            Color.Orange, 220, ButtonBorderStyle.Solid,
            //                            Color.White, 0, ButtonBorderStyle.Solid);  
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
            //                            Color.Black, 1, ButtonBorderStyle.Inset,
            //                            Color.Black, 1, ButtonBorderStyle.Inset,
            //                            Color.Orange, 1615, ButtonBorderStyle.Inset,
            //                            Color.Black, 1, ButtonBorderStyle.Inset);
            //// Color.Orange, 1615, ButtonBorderStyle.Solid,
                                     //   Color.Black, 1, ButtonBorderStyle.Inset);
        }

        private void Panels_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
            //                            Color.White, 0, ButtonBorderStyle.Solid,
            //                            Color.White, 0, ButtonBorderStyle.Solid,
            //                            Color.Orange, 220, ButtonBorderStyle.Solid,
            //                            Color.Orange, 123, ButtonBorderStyle.Solid);
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TaskNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskNameTextBox.Text.ToString()))
            {
                TaskNameLabel.Visible = false;
            }
            else
            {
                TaskNameLabel.Visible = true;
            }
        }

        private void AddFilesPPRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            if (AddFilesPPRadioButton.Checked)
            {
                AddFilesComboBox.Visible = true;
            }
            else
            {
                AddFilesComboBox.Visible = false;
            }
        }

        private void FindaWorkerRadio2_CheckedChanged(object sender, EventArgs e)
        {
            if (FindaWorkerRadio2.Checked)
            {
                FindaWorkerRadio2.BackColor = Color.DarkSeaGreen;
                FindaWorkerRadio3.BackColor = Color.White;
            }
            else if (FindaWorkerRadio3.Checked)
            {
                FindaWorkerRadio2.BackColor = Color.White;
                FindaWorkerRadio3.BackColor = Color.DarkSeaGreen;
            }
        }

      

             

    }

    #region REQUEST AND RESPONSE CLASSES.
    public class SignInRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool remember_me { get; set; }
    }

    public class SignInResponse
    {
        public string username { get; set; }
        public string auth_token { get; set; }
    }

    public class UploadResponse
    {
        public string key { get; set; }
    }

#endregion
}
