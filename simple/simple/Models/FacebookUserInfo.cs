using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple.Models
{
    public class FacebookUserInfo
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string id { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public string first_name { get; set; }

        [Newtonsoft.Json.JsonProperty("gender")]
        public string gender { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string name { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public string last_name { get; set; }

        [Newtonsoft.Json.JsonProperty("middle_name")]
        public string middle_name { get; set; }

        [Newtonsoft.Json.JsonProperty("verified")]
        public string verified { get; set; }
    }
}
