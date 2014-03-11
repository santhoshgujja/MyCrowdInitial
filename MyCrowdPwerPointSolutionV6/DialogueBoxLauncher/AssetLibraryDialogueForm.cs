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

           

            //splitContainer1.SplitterDistance = ImagesButton.Size.Width + 3;

        }

        public IDictionary<string, string> fileNamePath = new Dictionary<string, string>();
        string path;
        Dictionary<string,string> fileNamesList = new Dictionary<string,string>();
        DirectoryInfo dir = new DirectoryInfo(System.IO.Path.GetTempPath()).CreateSubdirectory("MyCrowdDownloadedFiles");

        private void ImagesButton_Click(object sender, EventArgs e)
        {
           
            LoadData(dir.ToString(),"Images");

            Image_AfterClick.Visible = true;
            Documents_AfterClick.Visible = false;
            ImagesButton.Visible = false;
            DocumentsButton.Visible = true;

        }

        private void AssetLibraryDialogueForm_Load(object sender, EventArgs e)
        {
            small_afterClick.Visible = true;
            medium_afterClick.Visible = false;
            large_afterclick.Visible = false;
            small_beforeclick.Visible = false;
            medium_beforeClick.Visible = true;
            large_beforeclick.Visible = true;
            ListviewData.View = View.List;

            Image_AfterClick.Visible = true;
            Documents_AfterClick.Visible = false;
            ImagesButton.Visible = false;
            DocumentsButton.Visible = true;

            ////Delete Existing files
            //DeleteFiles();

            ////Get SigninPassword
            //string password = GetSignInPassword();
            ////Get Assets List
            //fileNamesList = GetAssetsKeyList(password);
            ////download Images
            //DownloadFiles(fileNamesList, dir);
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

        private void DownloadFiles(Dictionary<string,string> fileNamesList, DirectoryInfo dir)
        {
            foreach (KeyValuePair<string,string> filename in fileNamesList)
            {
                string new_filename;

                if (filename.Value.IndexOf(':') > 0 || filename.Value.Contains("regions/"))
                {
                    continue;
                }
                else{

                    new_filename = filename.Value;
                }
                    var file = new FileInfo(Path.Combine(dir.FullName, new_filename));

                    //get the data to this file
                    var clientdownload = new RestClient("https://staging.mycrowd.com/api/download?key="+filename.Key);
                    var requestRestdownload = new RestRequest(Method.GET);
                    var restResponsedownload = clientdownload.Execute(requestRestdownload);
                    File.WriteAllBytes(file.ToString(), restResponsedownload.RawBytes);
            }
        }

        private Dictionary<string,string> GetAssetsKeyList(string password)
        {   
            Dictionary<string,string> returnlist = new Dictionary<string,string>();
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
                    if (asset.AssetFiles != null && asset.AssetFiles.Length > 0)
                    {
                        if (!returnlist.ContainsKey(asset.AssetFiles[0].LookupKey))
                        {
                            returnlist.Add(asset.AssetFiles[0].LookupKey, asset.AssetFiles[0].Name);
                        }
                        
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
            string filepath =  path +"\\" + fileName;
            Process.Start(filepath);
                       
        }

        private void DocumentsButton_Click(object sender, EventArgs e)
        {
            LoadData(dir.ToString(),"Documents");

            Image_AfterClick.Visible = false;
            Documents_AfterClick.Visible = true;
            ImagesButton.Visible = true;
            DocumentsButton.Visible = false;
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
                                    //Path.GetFileName(path)
                string fileName = Path.GetFileName(file);//file.Substring(path.Length);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void small_beforeclick_Click(object sender, EventArgs e)
        {
            ListviewData.View = View.SmallIcon;

            medium_beforeClick.Visible = true;
            small_beforeclick.Visible = false;
            large_beforeclick.Visible = true;

            medium_afterClick.Visible = false;
            small_afterClick.Visible = true;
            large_afterclick.Visible = false;

        }

        private void medium_beforeClick_Click(object sender, EventArgs e)
        {
            ListviewData.View = View.Tile;

            medium_beforeClick.Visible = false;
            small_beforeclick.Visible = true;
            large_beforeclick.Visible = true;

            medium_afterClick.Visible = true;
            small_afterClick.Visible = false;
            large_afterclick.Visible = false;
        }

        private void large_beforeclick_Click(object sender, EventArgs e)
        {
            ListviewData.View = View.LargeIcon;

            medium_beforeClick.Visible = true;
            small_beforeclick.Visible = true;
            large_beforeclick.Visible = false;

            medium_afterClick.Visible = false;
            small_afterClick.Visible = false;
            large_afterclick.Visible = true;
        }

    }
   
}
