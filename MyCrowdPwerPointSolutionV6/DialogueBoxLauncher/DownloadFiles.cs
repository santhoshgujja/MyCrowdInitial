using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RestSharp;
using RestSharp.Serializers;

using Assets;
using System.IO;

namespace DialogueBoxLauncher
{
    public class DownloadFiles
    {
        Dictionary<string, string> fileNamesList = new Dictionary<string, string>();
        DirectoryInfo dir = new DirectoryInfo(System.IO.Path.GetTempPath()).CreateSubdirectory("MyCrowdDownloadedFiles");
        public DownloadFiles()
        {
            DeleteFiles();
              //Get SigninPassword
            string password = GetSignInPassword();
            //Get Assets List
            fileNamesList = GetAssetsKeyList(password);
            //download Images
            DownloadFilesFromWebsite(fileNamesList, dir);
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

        private void DownloadFilesFromWebsite(Dictionary<string, string> fileNamesList, DirectoryInfo dir)
        {
            foreach (KeyValuePair<string, string> filename in fileNamesList)
            {
                string new_filename;

                if (filename.Value.IndexOf(':') > 0 || filename.Value.Contains("regions/"))
                {
                    continue;
                }
                else
                {

                    new_filename = filename.Value;
                }
                var file = new FileInfo(Path.Combine(dir.FullName, new_filename));

                //get the data to this file
                var clientdownload = new RestClient("https://staging.mycrowd.com/api/download?key=" + filename.Key);
                var requestRestdownload = new RestRequest(Method.GET);
                var restResponsedownload = clientdownload.Execute(requestRestdownload);
                File.WriteAllBytes(file.ToString(), restResponsedownload.RawBytes);
            }
        }

        private Dictionary<string, string> GetAssetsKeyList(string password)
        {
            Dictionary<string, string> returnlist = new Dictionary<string, string>();
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

            List<AssetsList> assetsList = assetsListResponse.AssetsList.ToList();
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
    }
}
