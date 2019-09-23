using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace IassetTechnicalTest.Services.Model
{
    public class CountryAPIModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dial_code")]
        public string DialCode { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}