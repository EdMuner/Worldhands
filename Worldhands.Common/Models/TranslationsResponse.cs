﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Worldhands.Common.Models
{
    public class TranslationsResponse
    {
        [JsonProperty(PropertyName = "de")]
        public string Germany { get; set; }

        [JsonProperty(PropertyName = "es")]
        public string Spanish { get; set; }

        [JsonProperty(PropertyName = "fr")]
        public string French { get; set; }

        [JsonProperty(PropertyName = "ja")]
        public string Japanese { get; set; }

        [JsonProperty(PropertyName = "it")]
        public string Italian { get; set; }

        [JsonProperty(PropertyName = "br")]
        public string Brazilian { get; set; }

        [JsonProperty(PropertyName = "pt")]
        public string Portuges { get; set; }

        [JsonProperty(PropertyName = "nl")]
        public string Dutch { get; set; }

        [JsonProperty(PropertyName = "hr")]
        public string Croatian { get; set; }

        [JsonProperty(PropertyName = "fa")]
        public string Danish { get; set; }
    }
}
