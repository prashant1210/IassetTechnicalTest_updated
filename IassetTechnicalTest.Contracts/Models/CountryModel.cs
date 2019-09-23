using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IassetTechnicalTest.Models
{
    public class CountryModel
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }

    public class CityModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}