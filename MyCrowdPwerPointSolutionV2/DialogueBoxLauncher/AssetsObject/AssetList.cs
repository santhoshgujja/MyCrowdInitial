﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assets
{

    public class AssetList
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("asset_type")]
        public string AssetType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("display_key")]
        public string DisplayKey { get; set; }

        [JsonProperty("asset_collection_ids")]
        public int[] AssetCollectionIds { get; set; }

        [JsonProperty("source_id")]
        public int? SourceId { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("visible_in_library")]
        public bool VisibleInLibrary { get; set; }

        [JsonProperty("asset_files")]
        public AssetFile[] AssetFiles { get; set; }
    }

}