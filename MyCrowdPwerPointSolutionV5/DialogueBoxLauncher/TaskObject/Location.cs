﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mycrowd.Task.Model;

namespace Mycrowd.Task.Model
{

    public class Location
    {

        [JsonProperty("xpath")]
        public string Xpath { get; set; }

        [JsonProperty("selector")]
        public string Selector { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }
    }

}
