﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mycrowd.Task.Model
{

    public class AssetFilesAttribute
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lookup_key")]
        public string LookupKey { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

}
