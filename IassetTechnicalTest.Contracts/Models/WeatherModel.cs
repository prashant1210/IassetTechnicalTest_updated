using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IassetTechnicalTest.Models
{
    public class WeatherModel
    {
        public string Location { get; set; }
        public string Time { get; set; }
        public object Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyConditions { get; set; }
        public object Temperature { get; set; }
        public string DewPoint { get; set; }
        public string RelativeHumidity { get; set; }
        public string Pressure { get; set; }
        
    }
}