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
using System.IO;
using System.Threading;

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

        bool creative_Green_display = false;
        bool Code_Green_display = false;
        bool Copywriting_Green_display = false;
        bool Research_Green_display = false;
        bool FW_Public_Green_display = false;
        bool FW_Private_Green_display = false;

        bool taskCategorySuccess = false;
        bool DescTaskSuccess = false;
        bool SetaPriceSuccess = false;
        bool FindaWorkerSuccess = false;
        bool ConfirmSuccess = false;

        public advancedSettingsDialog()
        {
            
            
            InitializeComponent();
            PerformInitialSettings();
            CheckPowerpointrunning();

            //splitContainer1.SplitterDistance = DescribeTask_Red.Width + 100;
        }

        private void PerformInitialSettings()
        {
            AddfilesMaximize.Visible = true;
            AddFiles_Minimize.Visible = false;
            groupBox1.Visible = false;
            Desc_Next2_LightBlue.Visible = false;
            DescribeTaskNext.Visible = false;
            

            TC_Creative_Grey.Visible = true;
            TC_Creative_Green.Visible = false;
            TC_Creative_Blue.Visible = false;
            TC_Code_Blue.Visible = false;
            TC_Code_Green.Visible = false;
            TC_Code_Grey.Visible = true;
            TC_Research_Grey.Visible = true;
            TC_Research_Green.Visible = false;
            TC_Research_Blue.Visible = false;
            TC_Copywriting_Blue.Visible = false;
            TC_Copywriting_Green.Visible = false;
            TC_Copywriting_Grey.Visible = true;

            FW_Public_Green.Visible = false;
            FW_Public_Grey.Visible = true;
            FW_Public_Blue.Visible = false;
            FW_private_Green.Visible = false;
            FW_private_Blue.Visible = false;
            FW_private_Grey.Visible = true; 


            AddfilesMaximize.Visible = true;
            AddFiles_Minimize.Visible = false;

            DescribeTaskDisplayColor("Grey");
            TaskCategoryDisplayColor("Grey");
            SetaPriceColor("Grey"); 
            FindaWorkerColor("Grey");
            ConfirmColor("Grey");

            AddFilesComboBox.Visible = false;
            HideAddFilesTextAndLabels();
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
            //ValidateTasks();
            HideAllPanels();
            HideAddFilesTextAndLabels();
            DescribeTheTaskPanel.Visible = true;
        }

        private void DescribeTask_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateDescribe();
            DescribeTheTaskPanel.Visible = true;
        }

        private void taskCategory_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTaskCategory();
            TaskCategoryPanel.Visible = true;
        }

        private void AddFiles_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
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
            ValidateSetaprice();
            SetaPricePanel.Visible = true;

        }

        private void HideAllPanels() 
        {
            TaskCategoryPanel.Visible = false;
            DescribeTheTaskPanel.Visible = false;
            ConfirmPanel.Visible = false;
            FindaWorkerPanel.Visible = false;
            SetaPricePanel.Visible = false;
        }

        private void FindaWorker_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Validatefindaworker();
            FindaWorkerPanel.Visible = true;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateConfirm();
            ConfirmPanel.Visible = true;
        }

        private void FindaWorkerNext_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Validatefindaworker();
            ConfirmPanel.Visible = true;
        }

        private void FindaWorkerPrevious_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Validatefindaworker();
            SetaPricePanel.Visible = true;
        }

        private void SetaPriceNext_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateSetaprice();
            FindaWorkerPanel.Visible = true;
        }

        private void SetaPricePrevious_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateSetaprice();
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
                //AddFilesPanel.Visible = true;
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
                //AddFilesPanel.Visible = true;
            }
            
        }

        private void DescribeTaskNext_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTasks();
            
            bool pptResult = ValidatePPTs();

            if (pptResult)
            {
                slidesValidation.Visible = false;
            }
            else
            {
                DescribeTaskDisplayColor("red");
                slidesValidation.Visible = true;
            }
            TaskCategoryPanel.Visible = true;
        }

        private void TaskCategoryNext_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTaskCategory();
            SetaPricePanel.Visible = true;
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
            ValidateSetaprice();
            TaskCategoryPanel.Visible = true;
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
            //TaskCategory
            if (creative_Green_display || Code_Green_display || Copywriting_Green_display || Research_Green_display)
            {
                TaskCategoryDisplayColor("green");
            }
            else
            {
                TaskCategoryDisplayColor("red");
            }
            //Describe Task
            if ((string.IsNullOrEmpty(taskDescriptionText.Text.ToString())) || TaskNameTextBox.Text == "Enter a Task Name" || taskDescriptionText.Text == "Enter a description" || (string.IsNullOrEmpty(TaskNameTextBox.Text.ToString())))
            {
                DescribeTaskDisplayColor("red");
            }
            else
            {
                DescribeTaskDisplayColor("green");
            }
            //Setaprice
            if (SetaPricePriceValue.Value < decimal.Parse("5"))
            {
                    SetaPriceColor("red");
            }
            else
            {
                SetaPriceColor("green");
            }

            //findaworker
            if (FW_Public_Green_display || FW_Private_Green_display)
            {
                FindaWorkerColor("green");
            }
            else
            {
                FindaWorkerColor("red");
            }

            //confirmcolor
            if (ConfirmCheckBox.Checked)
            {
                ConfirmColor("green");
            }
            else
            {
                ConfirmColor("red");
            }
        }

        public void ValidateDescribe()
        {
            if ((string.IsNullOrEmpty(taskDescriptionText.Text.ToString())) || TaskNameTextBox.Text == "Enter a Task Name" || taskDescriptionText.Text == "Enter a description" || (string.IsNullOrEmpty(TaskNameTextBox.Text.ToString())))
            {
                DescribeTaskDisplayColor("red");
            }
            else
            {
                DescribeTaskDisplayColor("green");
            }
        }
        public void ValidateTaskCategory()
        {
            if (creative_Green_display || Code_Green_display || Copywriting_Green_display || Research_Green_display)
            {
                TaskCategoryDisplayColor("green");
            }
            else
            {
                TaskCategoryDisplayColor("red");
            }
        }
        public void ValidateSetaprice()
        {
            if (SetaPricePriceValue.Value < decimal.Parse("5"))
            {
                SetaPriceColor("red");
            }
            else
            {
                SetaPriceColor("green");
            }
        }
        public void Validatefindaworker()
        {
            if (FW_Public_Green_display || FW_Private_Green_display)
            {
                FindaWorkerColor("green");
            }
            else
            {
                FindaWorkerColor("red");
            }
        }
        public void ValidateConfirm()
        {
            if (ConfirmCheckBox.Checked)
            {
                ConfirmColor("green");
            }
            else
            {
                ConfirmColor("red");
            }
        }

        #endregion

        #region DisplayColor

        //DescribeTaskDisplayColor
        private void DescribeTaskDisplayColor(string color)
        {
            if (color.ToLower() == "red")
            {
                DescribeTask_Red.Visible = true;
                DescribeTask_Green.Visible = false;
                DescribeTask.Visible = false;
                TaskDesc_error.Visible = true;
                DescTaskSuccess = false;

            }
            else if (color.ToLower() == "green")
            {
                DescribeTask_Red.Visible = false;
                DescribeTask_Green.Visible = true;
                DescribeTask.Visible = false;
                TaskDesc_error.Visible = false;
                DescTaskSuccess = true;
            }
            else if (color.ToLower() == "grey")
            {
                DescribeTask_Red.Visible = false;
                DescribeTask_Green.Visible = false;
                DescribeTask.Visible = true;
                TaskDesc_error.Visible = false;
                DescTaskSuccess = false;
            }
            else
            {
                DescribeTask_Red.Visible = false;
                DescribeTask_Green.Visible = false;
                DescribeTask.Visible = true;
                TaskDesc_error.Visible = false;
                DescTaskSuccess = false;
            }
        }
        //TaskCategory
        private void TaskCategoryDisplayColor(string color)
        {
            if (color.ToLower() == "red")
            {
                TaskCategory_Red.Visible = true;
                taskCategory.Visible = false;
                TasCategory_Grey.Visible = false;
                TC_Error.Visible = true;
                taskCategorySuccess = false;

            }
            else if (color.ToLower() == "green")
            {
                TaskCategory_Red.Visible = false;
                taskCategory.Visible = true;
                TasCategory_Grey.Visible = false;
                TC_Error.Visible = false;
                taskCategorySuccess = true;
            }
            else if (color.ToLower() == "grey")
            {
                TaskCategory_Red.Visible = false;
                taskCategory.Visible = false;
                TasCategory_Grey.Visible = true;
                TC_Error.Visible = false;
                taskCategorySuccess = false;
            }
            else
            {
                TaskCategory_Red.Visible = false;
                taskCategory.Visible = false;
                TasCategory_Grey.Visible = true;
                TC_Error.Visible = false;
                taskCategorySuccess = false;
            }
        }
        //SetaPrice
        private void SetaPriceColor(string color)
        {
            if (color.ToLower() == "red")
            {
                SetaPrice_Red.Visible = true;
                SetaPrice_Error.Visible = true;
                SetaPrice_Grey.Visible = false;
                SetThePrice.Visible = false;
                SetaPriceSuccess = false;

            }
            else if (color.ToLower() == "green")
            {
                SetaPrice_Red.Visible = false;
                SetaPrice_Error.Visible = false;
                SetaPrice_Grey.Visible = false;
                SetThePrice.Visible = true;
                SetaPriceSuccess = true;
            }
            else if (color.ToLower() == "grey")
            {
                SetaPrice_Red.Visible = false;
                SetaPrice_Error.Visible = false;
                SetaPrice_Grey.Visible = true;
                SetThePrice.Visible = false;
                SetaPriceSuccess = false;
            }
            else
            {
                SetaPrice_Red.Visible = false;
                SetaPrice_Error.Visible = false;
                SetaPrice_Grey.Visible = true;
                SetThePrice.Visible = false;
                SetaPriceSuccess = false;
            }
        }
        //FindaWorker
        private void FindaWorkerColor(string color)
        {
            if (color.ToLower() == "red")
            {
                FindaWorker_Error.Visible = true;
                FindaWorker_Red.Visible = true;
                FindaWorker_Grey.Visible = false;
                FindaWorker.Visible = false;
                FindaWorkerSuccess = false;
            }
            else if (color.ToLower() == "green")
            {
                FindaWorker_Error.Visible = false;
                FindaWorker_Red.Visible = false;
                FindaWorker_Grey.Visible = false;
                FindaWorker.Visible = true;
                FindaWorkerSuccess = true;
            }
            else if (color.ToLower() == "grey")
            {
                FindaWorker_Error.Visible = false;
                FindaWorker_Red.Visible = false;
                FindaWorker_Grey.Visible = true;
                FindaWorker.Visible = false;
                FindaWorkerSuccess = false;
            }
            else
            {
                FindaWorker_Error.Visible = false;
                FindaWorker_Red.Visible = false;
                FindaWorker_Grey.Visible = true;
                FindaWorker.Visible = false;
                FindaWorkerSuccess = false;
            }
        }
        //Confirm
        private void ConfirmColor(string color)
        {
            if (color.ToLower() == "red")
            {
                Confirm_Red.Visible = true;
                Confirm_Error.Visible = true;
                Confirm_Grey.Visible = false;
                Confirm.Visible = false;
                ConfirmSuccess = false;
            }
            else if (color.ToLower() == "green")
            {
                Confirm_Red.Visible = false;
                Confirm_Error.Visible = false;
                Confirm_Grey.Visible = false;
                Confirm.Visible = true;
                ConfirmSuccess = true;
            }
            else if (color.ToLower() == "grey")
            {
                Confirm_Red.Visible = false;
                Confirm_Error.Visible = false;
                Confirm_Grey.Visible = true;
                Confirm.Visible = false;
                ConfirmSuccess = false;
            }
            else
            {
                Confirm_Red.Visible = false;
                Confirm_Error.Visible = false;
                Confirm_Grey.Visible = true;
                Confirm.Visible = false;
                ConfirmSuccess = false;
            }
        }

        #endregion

      

        private void ConfirmPublishTask_Click(object sender, EventArgs e)
        {
            bool isSuccessfull = true;
            StringBuilder message = new StringBuilder();
            //Perform Validations
            HideAllPanels();
            ValidateTasks();
            if (!taskCategorySuccess || !DescTaskSuccess || !SetaPriceSuccess || !FindaWorkerSuccess || !ConfirmSuccess)
            {
                if (!DescTaskSuccess)
                {
                    DescribeTheTaskPanel.Visible = true;
                }
                else if (!taskCategorySuccess) {
                    TaskCategoryPanel.Visible = true;
                }
                else if (!SetaPriceSuccess) {
                    SetaPricePanel.Visible = true;
                }
                else if (!FindaWorkerSuccess)
                {
                    FindaWorkerPanel.Visible = true;
                }
                else if (!ConfirmSuccess)
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

                if (AddFilesPPRadioButton.Checked || !string.IsNullOrWhiteSpace(AddFilesPathsList.Text))
                {
                    Thread t = new Thread(new System.Threading.ThreadStart(DownloadingFiles));
                    t.IsBackground = true;
                    t.Start();
                }
            }
   
           
        }

        public void DownloadingFiles()
        {
            new DownloadFiles();
        }

        #region publishing Task

        private void PostTaskFinal()
        {
           

            //UploadFiles
            Dictionary<string,string> uploadFileKeyslist = UploadFiles();
           
            string password = GetSignInPassword();
            Task task = GetTaskData(uploadFileKeyslist);
            string taskbody = Newtonsoft.Json.JsonConvert.SerializeObject(task);
            string response = UploadTaskData(task, password);

        }

        private Dictionary<string,string> UploadFiles()
        {
             var client = new RestClient("https://staging.mycrowd.com/api/upload");
             var requestRest = new RestRequest(Method.POST);
             requestRest.AddHeader("content-type", "application/json");
             Dictionary<string,string> responseFileList = new Dictionary<string,string>();
                

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
                        responseFileList.Add(UploadResponse.key,Path.GetFileName(filepath));
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
                responseFileList.Add(UploadResponse.key, "PPTSlides_" + Int64.Parse(DateTime.Now.ToString("yyyymmddhhMMss")).ToString() + ".pptx");
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

        private Task GetTaskData(Dictionary<string,string> uploadFileKeyslist)
        {

            Task task = new Task();
            task.Title = TaskNameTextBox.Text.ToString();
            task.JobType = (creative_Green_display) ? "design" :
                           (Code_Green_display) ? "web_development" :
                           (Copywriting_Green_display) ? "writing" :
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
            return task;
        }

        private AssetCollectionAttributes GetAssetCollectionAttributes(Dictionary<string,string> uploadFileKeyslist)
        {

            List<AssetsAttribute> assetattributescolletion = new List<AssetsAttribute>();

            if (uploadFileKeyslist != null && uploadFileKeyslist.Count > 0)
            {
                foreach (KeyValuePair<string,string> uploadfileKey in uploadFileKeyslist)
                {
                        AssetsAttribute asset_attribute = new AssetsAttribute()
                        {
                            AssetTypeName = (
                                                uploadfileKey.Value.ToLower().Contains(".png") || uploadfileKey.Value.ToLower().Contains(".jpg") ||
                                                uploadfileKey.Value.ToLower().Contains(".jpeg") || uploadfileKey.Value.ToLower().Contains(".gif") ||
                                                uploadfileKey.Value.ToLower().Contains(".bmp")
                                            )? "image":"document",
                            Name = uploadfileKey.Value,
                            Url = "NotNull",
                            //ContentType = "image/png",
                            Description = "Asset file Uploaded From PPT.",
                            AssetFilesAttributes = GetAssetFileAttribute(uploadfileKey)
                        };
                        assetattributescolletion.Add(asset_attribute);
                }

            }
            else
            {
               
                    AssetsAttribute asset_attribute = new AssetsAttribute()
                                                                {
                                                                    AssetTypeName = "document",
                                                                    Name = "Test",
                                                                    Url = "NotNull",
                                                                    ContentType = "",
                                                                    Description = "",
                                                                    AssetFilesAttributes = GetNullAssetFileAttribute()
                                                                };
                    assetattributescolletion.Add(asset_attribute);

                
            }
            return new AssetCollectionAttributes()
            {
                AssetsAttributes = assetattributescolletion.ToArray()
            };
        }

        private AssetFilesAttribute[] GetNullAssetFileAttribute()
        {
            List<AssetFilesAttribute> assetfileAttributelist = new List<AssetFilesAttribute>();
            AssetFilesAttribute assetfileAttribute = new AssetFilesAttribute();
            assetfileAttribute.Height = 1;
            assetfileAttribute.Width = 1;
            assetfileAttribute.Name = "Test";
            assetfileAttribute.LookupKey = "";

            assetfileAttributelist.Add(assetfileAttribute);

            return assetfileAttributelist.ToArray();
        }

        private AssetFilesAttribute[] GetAssetFileAttribute(KeyValuePair<string,string> uploadfileKey)
        {
            List<AssetFilesAttribute> assetfileAttributelist = new List<AssetFilesAttribute>();
            AssetFilesAttribute assetfileAttribute = new AssetFilesAttribute();
            assetfileAttribute.Height = 540;
            assetfileAttribute.Width = 540;
            assetfileAttribute.Name = uploadfileKey.Value;
            assetfileAttribute.LookupKey = uploadfileKey.Key;

            assetfileAttributelist.Add(assetfileAttribute);

            return assetfileAttributelist.ToArray();
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

        private void ConfirmCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmSaveDraft_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your task has been Saved. It will be added to your Task List.");
        }

        #endregion

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
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

     

        private void TC_Creative_Grey_MouseEnter(object sender, EventArgs e)
        {
            //TC_Creative_Grey.Hide();
            TC_Creative_Blue.Visible = true;
            TC_Creative_Green.Visible = false;
            TC_Creative_Grey.Visible = false;
        }

        private void TC_Creative_Blue_Click(object sender, EventArgs e)
        {
            TC_Creative_Blue.Visible = false;
            TC_Creative_Grey.Visible = false;
            TC_Creative_Green.Visible = true;
            creative_Green_display = true;

            Research_Green_display = false;
            TC_Research_Grey.Visible = true;
            TC_Research_Green.Visible = false;
            Copywriting_Green_display = false;
            TC_Copywriting_Grey.Visible = true;
            TC_Copywriting_Green.Visible = false;
            Code_Green_display = false;
            TC_Code_Grey.Visible = true;
            TC_Code_Green.Visible = false;
        }

        private void TC_Creative_Blue_MouseLeave(object sender, EventArgs e)
        {
            if (!creative_Green_display)
            {
                TC_Creative_Blue.Visible = false;
                TC_Creative_Green.Visible = false;
                TC_Creative_Grey.Visible = true;
            }
          
        }

        private void TC_Creative_Grey_MouseClick(object sender, MouseEventArgs e)
        {
            TC_Creative_Green.Visible = true;
            TC_Creative_Blue.Visible = false;
            TC_Creative_Grey.Visible = false;
        }

        private void TC_Code_Grey_MouseHover(object sender, EventArgs e)
        {
            TC_Code_Blue.Visible = true;
            TC_Code_Green.Visible = false;
            TC_Code_Grey.Visible = false;
        }

        private void TC_Code_Blue_Click(object sender, EventArgs e)
        {
            TC_Code_Blue.Visible = false;
            TC_Code_Green.Visible = true;
            Code_Green_display = true;
            TC_Code_Grey.Visible = false;

            TC_Creative_Grey.Visible = true;
            creative_Green_display = false;
            TC_Creative_Green.Visible = false;
            Research_Green_display = false;
            TC_Research_Green.Visible = false;
            TC_Research_Grey.Visible = true;
            Copywriting_Green_display = false;
            TC_Copywriting_Grey.Visible = true;
            TC_Copywriting_Green.Visible = false;
        }

        private void TC_Code_Blue_MouseLeave(object sender, EventArgs e)
        {
            if (!Code_Green_display)
            {
                TC_Code_Blue.Visible = false;
                TC_Code_Green.Visible = false;
                TC_Code_Grey.Visible = true;
            }
        }

        private void TC_Copywriting_Grey_MouseHover(object sender, EventArgs e)
        {
            TC_Copywriting_Blue.Visible = true;
            TC_Copywriting_Green.Visible = false;
            TC_Copywriting_Grey.Visible = false;
        }

        private void TC_Copywriting_Blue_MouseLeave(object sender, EventArgs e)
        {
            if (!Copywriting_Green_display)
            {
                TC_Copywriting_Blue.Visible = false;
                TC_Copywriting_Green.Visible = false;
                TC_Copywriting_Grey.Visible = true;
            }
        }

        private void TC_Copywriting_Blue_Click(object sender, EventArgs e)
        {
            TC_Copywriting_Blue.Visible = false;
            TC_Copywriting_Green.Visible = true;
            Copywriting_Green_display = true;
            TC_Copywriting_Grey.Visible = false;

            Code_Green_display = false;
            TC_Code_Grey.Visible = true;
            TC_Code_Green.Visible = false;
            TC_Creative_Grey.Visible = true;
            creative_Green_display = false;
            TC_Creative_Green.Visible = false;
            Research_Green_display = false;
            TC_Research_Grey.Visible = true;
            TC_Research_Green.Visible = false;
        }

        private void TC_Research_Grey_MouseEnter(object sender, EventArgs e)
        {
            TC_Research_Blue.Visible = true;
            TC_Research_Green.Visible = false;
            TC_Research_Grey.Visible = false;
        }

        private void TC_Research_Blue_Click(object sender, EventArgs e)
        {
            TC_Research_Blue.Visible = false;
            TC_Research_Green.Visible = true;
            Research_Green_display = true;
            TC_Research_Grey.Visible = false;

            Copywriting_Green_display = false;
            TC_Copywriting_Grey.Visible = true;
            TC_Copywriting_Green.Visible = false;
            Code_Green_display = false;
            TC_Code_Grey.Visible = true;
            TC_Code_Green.Visible = false;
            TC_Creative_Grey.Visible = true;
            creative_Green_display = false;
            TC_Creative_Green.Visible = false;

        }

        private void TC_Research_Blue_MouseLeave(object sender, EventArgs e)
        {
            if (!Research_Green_display)
            {
                TC_Research_Blue.Visible = false;
                TC_Research_Green.Visible = false;
                TC_Research_Grey.Visible = true;
            }
        }

        private void FW_Public_Grey_MouseEnter(object sender, EventArgs e)
        {
            FW_Public_Blue.Visible = true;
            FW_Public_Green.Visible = false;
            FW_Public_Grey.Visible = false;
        }

        private void FW_Public_Blue_Click(object sender, EventArgs e)
        {
            FW_Public_Blue.Visible = false;
            FW_Public_Green.Visible = true;
            FW_Public_Green_display = true;
            FW_Public_Grey.Visible = false;


            FW_private_Green.Visible = false;
            FW_private_Grey.Visible = true;
            FW_Private_Green_display = false;
        }

        private void FW_Public_Blue_MouseLeave(object sender, EventArgs e)
        {
            if (!FW_Public_Green_display)
            {
                FW_Public_Blue.Visible = false;
                FW_Public_Green.Visible = false;
                FW_Public_Grey.Visible = true;
            }
        }

        private void FW_private_Grey_MouseEnter(object sender, EventArgs e)
        {
            FW_private_Blue.Visible = true;
            FW_private_Green.Visible = false;
            FW_private_Grey.Visible = false;
        }

        private void FW_private_Blue_Click(object sender, EventArgs e)
        {
            FW_private_Blue.Visible = false;
            FW_Private_Green_display = true;
            FW_private_Green.Visible = true;
            FW_private_Grey.Visible = false;

            FW_Public_Green.Visible = false;
            FW_Public_Green_display = false;
            FW_Public_Grey.Visible = true;
        }

        private void FW_private_Blue_MouseLeave(object sender, EventArgs e)
        {
            if (!FW_Private_Green_display)
            {
                FW_private_Blue.Visible = false;
                FW_private_Green.Visible = false;
                FW_private_Grey.Visible = true;
            }
        }

        private void SetaPriceCouponCode_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SetaPriceCouponCode.Text))
            {
                if (SetaPriceCouponCode.Text.Contains("Coupon Code"))
                {
                    SetaPriceCouponCode.Clear();
                }
            }
        }

        private void SetaPriceCouponCode_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(SetaPriceCouponCode.Text))
            {
                SetaPriceCouponCode.Text = "Coupon Code";
            }

        }

        private void TaskNameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskNameTextBox.Text))
            {
                if (TaskNameTextBox.Text.Contains("Enter a Task Name"))
                {
                    TaskNameTextBox.Clear();
                }
            }
        }

        private void TaskNameTextBox_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TaskNameTextBox.Text))
            {
                TaskNameTextBox.Text = "Enter a Task Name";
            }
        }

        private void SetaPriceCouponCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SetaPriceCouponCode.Text))
            {
                SetaPriceCouponCode.Text = "Coupon Code";
            }
        }

        private void taskDescriptionText_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(taskDescriptionText.Text))
            {
                if (taskDescriptionText.Text.Contains("Enter a description"))
                {
                    taskDescriptionText.Clear();
                }
            }
        }

        private void taskDescriptionText_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskDescriptionText.Text))
            {
                taskDescriptionText.Text = "Enter a description";
            }
        }

        private void AddfilesMaximize_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            Desc_Next2_LightBlue.Visible = true;
            Desc_Next1_DarkBlue.Visible = false;
            Desc_Next1_LightBlue.Visible = false;
            AddFiles_Minimize.Visible = true;
            AddfilesMaximize.Visible = false;
            if (TotalSlides() == 0)
            {
                AddFilesPPRadioButton.Visible = false;
            }
            else
            {
                AddFilesPPRadioButton.Visible = true;
            }
        }

        private void AddFiles_Minimize_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            Desc_Next2_LightBlue.Visible = false;
            Desc_Next1_LightBlue.Visible = true;
            AddFiles_Minimize.Visible = false;
            AddfilesMaximize.Visible = true;
        }

        private void Desc_Next1_LightBlue_MouseEnter(object sender, EventArgs e)
        {
            Desc_Next1_DarkBlue.Visible = true;
            Desc_Next1_LightBlue.Visible = false;

        }

        private void Desc_Next1_DarkBlue_MouseLeave(object sender, EventArgs e)
        {
            Desc_Next1_DarkBlue.Visible = false;
            Desc_Next1_LightBlue.Visible = true;
        }

        private void Desc_Next1_DarkBlue_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateDescribe();
            TaskCategoryPanel.Visible = true;
            
        }

        private void Desc_Next2_LightBlue_MouseEnter(object sender, EventArgs e)
        {
            DescribeTaskNext.Visible = true;
            Desc_Next2_LightBlue.Visible = false;

        }

        private void DescribeTaskNext_MouseLeave(object sender, EventArgs e)
        {
            DescribeTaskNext.Visible = false;
            Desc_Next2_LightBlue.Visible = true;
        }

        private void TC_Next_LBlue_MouseEnter(object sender, EventArgs e)
        {
            TC_Next_LBlue.Visible = false;
            TaskCategoryNext.Visible = true;
        }

        private void TaskCategoryNext_MouseLeave(object sender, EventArgs e)
        {
            TC_Next_LBlue.Visible = true;
            TaskCategoryNext.Visible = false;
        }

        private void TC_Prev_LGrey_MouseEnter(object sender, EventArgs e)
        {
            TC_Prev_DarkG.Visible = true;
            TC_Prev_LGrey.Visible = false;
        }

        private void TC_Prev_DarkG_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateTaskCategory(); 
            DescribeTheTaskPanel.Visible = true;
        }

        private void TC_Prev_DarkG_MouseLeave(object sender, EventArgs e)
        {
            FW_Prev_LGrey.Visible = true;
            FW_Prev_DGrey.Visible = false;
        }

        private void FW_Prev_LGrey_MouseEnter(object sender, EventArgs e)
        {
            FW_Prev_LGrey.Visible = false;
            FW_Prev_DGrey.Visible = true;
        }

        private void FW_Prev_DGrey_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Validatefindaworker();
            SetaPricePanel.Visible = true;
        }

        private void FW_Prev_DGrey_MouseLeave(object sender, EventArgs e)
        {
            FW_Prev_LGrey.Visible = true;
            FW_Prev_DGrey.Visible = false;
        }

        private void FW_Next_LBlue_MouseEnter(object sender, EventArgs e)
        {
            FW_Next_DBlue.Visible = true;
            FW_Next_LBlue.Visible = false;
        }

        private void FW_Next_DBlue_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            Validatefindaworker();
            ConfirmPanel.Visible = true;
        }

        private void FW_Next_DBlue_MouseLeave(object sender, EventArgs e)
        {
            FW_Next_DBlue.Visible = false;
            FW_Next_LBlue.Visible = true;
        }

        private void Confirm_Pub_LBlue_MouseEnter(object sender, EventArgs e)
        {
            ConfirmPublishTask.Visible = true;
            Confirm_Pub_LBlue.Visible = false;
        }

        private void Confirm_SaveDraft_LGrey_MouseEnter(object sender, EventArgs e)
        {
            ConfirmSaveDraft.Visible = true;
            Confirm_SaveDraft_LGrey.Visible = false;
        }

        private void ConfirmPublishTask_MouseLeave(object sender, EventArgs e)
        {
            ConfirmPublishTask.Visible = false;
            Confirm_Pub_LBlue.Visible = true;
        }

        private void ConfirmSaveDraft_MouseLeave(object sender, EventArgs e)
        {
            Confirm_SaveDraft_LGrey.Visible = true;
            ConfirmSaveDraft.Visible = false;

        }

        private void ConfirmCancel_MouseLeave(object sender, EventArgs e)
        {
            Confirm_Cancel_LGrey.Visible = true;
            ConfirmCancel.Visible = false;
        }

        private void Confirm_Cancel_LGrey_MouseEnter(object sender, EventArgs e)
        {
            Confirm_Cancel_LGrey.Visible = false;
            ConfirmCancel.Visible = true;
        }

        private void STP_Next_DBlue_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateSetaprice();
            FindaWorkerPanel.Visible = true;
        }

        private void STP_Next_DBlue_Leave(object sender, EventArgs e)
        {
            STP_Next_DBlue.Visible = false;
            STP_Next_LBlue.Visible = true;
        }

        private void AddFilesUploadFile_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogue1 = new OpenFileDialog();
            openFileDialogue1.Multiselect = true;
            AddFilesPathsList.Text = "";

            if (openFileDialogue1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePathsList = openFileDialogue1.FileNames;
            }
            if (filePathsList != null)
            {
                List<string> filesList = filePathsList.ToList<string>();
                foreach (string filepath in filesList)
                {
                    AddFilesPathsList.AppendText(filepath + "\n");
                }
            }
        }

        private void Desc_Next2_LightBlue_Click(object sender, EventArgs e)
        {
            HideAllPanels();
            ValidateDescribe();
            TaskCategoryPanel.Visible = true;
            bool pptResult = ValidatePPTs();

            if (pptResult)
            {
                slidesValidation.Visible = false;
            }
            else
            {
                DescribeTaskDisplayColor("red");
                slidesValidation.Visible = true;
            }
        }

        private void STP_Next_LBlue_MouseEnter(object sender, EventArgs e)
        {
            STP_Next_DBlue.Visible = true;
            STP_Next_LBlue.Visible = false;
        }

        private void STP_Prev_LGrey_MouseEnter(object sender, EventArgs e)
        {
            STP_Prev_LGrey.Visible = false;
            STP_Prev_DGrey.Visible = true;
        }

        private void STP_Prev_DGrey_MouseLeave(object sender, EventArgs e)
        {
            STP_Prev_LGrey.Visible = true;
            STP_Prev_DGrey.Visible = false;
        }

        private void AddFilesPPRadioButton_CheckedChanged(object sender, EventArgs e)
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

        private void AddFilesComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TaskCategoryPanel_Paint(object sender, PaintEventArgs e)
        {

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
