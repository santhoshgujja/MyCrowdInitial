using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

//word related info
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

//Namespace for Assets Object
using Assets;

//RestSharp
using RestSharp;
using RestSharp.Serializers;

namespace DialogueBoxLauncher
{
    public partial class AssetLibraryDialogueForm : Form
    {
        public AssetLibraryDialogueForm()
        {
            InitializeComponent();
        }

        public IDictionary<string, string> fileNamePath = new Dictionary<string, string>();
        string path;
        List<string> fileNamesList = new List<string>();
        DirectoryInfo dir = new DirectoryInfo(System.IO.Path.GetTempPath()).CreateSubdirectory("MyCrowdDownloadedFiles");

        private void ImagesButton_Click(object sender, EventArgs e)
        {
           
            LoadData(dir.ToString(),"Images");
        }

        private void AssetLibraryDialogueForm_Load(object sender, EventArgs e)
        {
            //Delete Existing files
            DeleteFiles();

            //Get SigninPassword
            string password = GetSignInPassword();
            //Get Assets List
            fileNamesList = GetAssetsKeyList(password);
            //download Images
            DownloadFiles(fileNamesList, dir);
            //display images
            LoadData(dir.ToString(),"Images");
        }

        private void DeleteFiles()
        {
            
            FileInfo[] existingfiles = dir.GetFiles();
            
            if (existingfiles != null && existingfiles.ToList().Count > 0)
            {
                foreach (FileInfo file in existingfiles.ToList())
                {
                    file.Delete();
                }
            }
           
        }

        private void DownloadFiles(List<string> fileNamesList, DirectoryInfo dir)
        {
            foreach (string filename in fileNamesList)
            {
                if(filename.Contains("regions/"))
                {
                    string new_filename = filename.Replace('/', '_');
                    var file = new FileInfo(Path.Combine(dir.FullName, new_filename));

                    //get the data to this file
                    var clientdownload = new RestClient("https://staging.mycrowd.com/api/download?key="+filename);
                    var requestRestdownload = new RestRequest(Method.GET);
                    var restResponsedownload = clientdownload.Execute(requestRestdownload);
                    File.WriteAllBytes(file.ToString(), restResponsedownload.RawBytes);
        

                }
            }
        }

        private List<string> GetAssetsKeyList(string password)
        {   List<string> returnlist = new List<string>();
            var clientGetAssets = new RestClient("https://mycrowd-dev.herokuapp.com/api/assets");
            var clientAssetsrequest = new RestRequest(Method.GET);
            clientAssetsrequest.AddHeader("Content-Type", "application/json");
            clientAssetsrequest.AddHeader("X-Auth-User", "powerpoint@mycrowd.com");
            clientAssetsrequest.AddHeader("X-Auth-Token", password);
            clientAssetsrequest.JsonSerializer = new CustomJsonSerializer();
            clientAssetsrequest.RequestFormat = DataFormat.Json;
            var clientTaskResponse = clientGetAssets.Execute(clientAssetsrequest);
            var nameValueresponse = "{ \"assets_List\" : " + clientTaskResponse.Content + "}";
            var assetsListResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Assets.Assets>(nameValueresponse);// .DeserializeObject<AssetList>(nameValueresponse);
          
            List<AssetsList> assetsList =   assetsListResponse.AssetsList.ToList();
            //now extract the lookupkeys if available
            if (assetsListResponse != null)
            {
                foreach (AssetsList asset in assetsListResponse.AssetsList.ToList())
                {
                   if(!string.IsNullOrWhiteSpace(asset.Name))
                   {
                       returnlist.Add(asset.Name);
                   }
                }
            }

            return returnlist;
        }

        #region Display

        private void largeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListviewData.View = View.LargeIcon;
        }

        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListviewData.View = View.SmallIcon;
        }

        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListviewData.View = View.List;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void ListviewData_DoubleClick(object sender, EventArgs e)
        {
            string fileName = null;
            if (ListviewData.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = ListviewData.SelectedItems;
                ListViewItem lvitem = items[0];
                fileName = lvitem.Text;
            }
            string filepath = path + fileName;
            Process.Start(filepath);
                       
        }

        private void DocumentsButton_Click(object sender, EventArgs e)
        {
            LoadData(dir.ToString(),"Documents");
        }

        private void LoadData(string elementPath,string filetype)
        {
            ListviewData.Items.Clear();
            fileNamePath.Clear();
            path = elementPath;
            string[] files = Directory.GetFiles(path);
            int index = 0;
            foreach (string file in files)
            {
                string fileName = file.Substring(path.Length);
                if (filetype.Contains("Image"))
                {
                    if (fileName.ToLower().Contains(".png") || fileName.ToLower().Contains(".jpg") || 
                        fileName.ToLower().Contains(".jpeg") || fileName.ToLower().Contains(".gif") ||
                        fileName.ToLower().Contains(".bmp")
                        )
                        {  
                            ListviewData.Items.Add(fileName);
                            ListviewData.Items[index].ImageIndex = 7;
                            index++;
                        }
                }
                else if (filetype.ToLower().Contains("document"))
                {

                    if (fileName.ToLower().Contains(".doc") )
                    {
                        ListviewData.Items.Add(fileName);
                        ListviewData.Items[index].ImageIndex = 3;
                        index++;
                    }
                    else if(fileName.ToLower().Contains(".docx"))
                    {
                        ListviewData.Items.Add(fileName);
                        ListviewData.Items[index].ImageIndex = 4;
                        index++;
                    }
                    else if (fileName.ToLower().Contains(".xls") )
                    {
                        ListviewData.Items.Add(fileName);
                        ListviewData.Items[index].ImageIndex = 15;
                        index++;
                    }
                    else if(fileName.ToLower().Contains(".xlsx"))
                    {
                        ListviewData.Items.Add(fileName);
                        ListviewData.Items[index].ImageIndex = 16;
                        index++;
                    }
                    else if (fileName.ToLower().Contains(".ppt"))
                    {
                        ListviewData.Items.Add(fileName);
                        ListviewData.Items[index].ImageIndex = 10;
                        index++;
                    }
                    else if(fileName.ToLower().Contains(".pptx"))
                    {
                        ListviewData.Items.Add(fileName);
                        ListviewData.Items[index].ImageIndex = 11;
                        index++;
                    }
                    else if (fileName.ToLower().Contains(".pdf"))
                    {
                        ListviewData.Items.Add(fileName);
                        ListviewData.Items[index].ImageIndex = 9;
                        index++;
                    }
                    else if (fileName.ToLower().Contains(".txt"))
                    {
                        ListviewData.Items.Add(fileName);
                        ListviewData.Items[index].ImageIndex = 13;
                        index++;
                    }
                    else if (fileName.ToLower().Contains(".psd"))
                    {
                        ListviewData.Items.Add(fileName);
                        ListviewData.Items[index].ImageIndex = 12;
                        index++;
                    }
                   
                }

                else
                {
                    ListviewData.Items.Add(fileName);
                    ListviewData.Items[index].ImageIndex = 5;
                    index++;
                }

                fileNamePath.Add(fileName, path);
                
            }
            ListviewData.Activation = ItemActivation.Standard;
        }

        private void LoadData_final(string elementPath)
        {
            ListviewData.Items.Clear();
            fileNamePath.Clear();
            ListviewData.SmallImageList = SmallIconsImagelist;
            ListviewData.Items.Add(new ListViewItem("Asset",0));
            ListviewData.Items.Add(new ListViewItem("Messages", 1));
            ListviewData.Items.Add(new ListViewItem("MycrowdLogo", 2));
            ListviewData.Items.Add(new ListViewItem("request", 3));
            ListviewData.Items.Add(new ListViewItem("task", 4));
            ListviewData.Items.Add(new ListViewItem("worker", 5));

                      
            //ListviewData.Items.Clear();
            //fileNamePath.Clear();
            //path = elementPath;
            //string[] files = Directory.GetFiles(path);
            

            //foreach (string file in files)
            //{
            //    string fileName = file.Substring(path.Length);
            //    ListviewData.Items.Add(fileName);
            //    fileNamePath.Add(fileName, path);
            //}
            //ListviewData.Activation = ItemActivation.Standard;
        }

        private void CodeButton_Click(object sender, EventArgs e)
        {
            LoadData(dir.ToString(),"Images");
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                       Color.Black, 1, ButtonBorderStyle.Inset,
                                       Color.Black, 1, ButtonBorderStyle.Inset,
                                       Color.Orange, 1615, ButtonBorderStyle.Solid,
                                       Color.Black, 1, ButtonBorderStyle.Inset);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                       Color.Black, 1, ButtonBorderStyle.Inset,
                                       Color.Black, 1, ButtonBorderStyle.Inset,
                                       Color.Orange, 1615, ButtonBorderStyle.Solid,
                                       Color.Black, 1, ButtonBorderStyle.Inset);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
   
}
