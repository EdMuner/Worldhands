using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Worldhands.Common.Models
{
    public class RegionalBlocResponse
    {
        [JsonProperty("acronym")]
        public string Acronym { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
