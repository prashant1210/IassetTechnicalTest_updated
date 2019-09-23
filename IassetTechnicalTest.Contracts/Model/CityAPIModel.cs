using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace IassetTechnicalTest.Services.Model
{
        public partial class CityAPIModel
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("coord")]
            public Coord Coord { get; set; }
        }

        public partial class Coord
        {
            [JsonProperty("lon")]
            public double Lon { get; set; }

            [JsonProperty("lat")]
            public double Lat { get; set; }
        }
    

}