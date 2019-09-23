using IassetTechnicalTest.Models;
using IassetTechnicalTest.Services.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace IassetTechnicalTest.Services
{
    public class CountryServices : ICountryServices
    {
        public List<CountryModel> GetCountry(string path)
        {
            try
            {
                var countryAPIList = CountryList(path);
                List<CountryModel> countries = countryAPIList.Select(x => new CountryModel
                {
                    CountryCode = x.Code,
                    CountryName = x.Name
                }).ToList();
                return countries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CityModel> GetCity(string path , string countryCode)
        {
            try
            {
                var cityAPI = CityList(path );
                List<CityModel> cities = cityAPI.Where(x => x.Country.ToUpper() == countryCode.ToUpper()).Select(x => new CityModel
                {
                    CityId = x.Id,
                    CityName = x.Name
                }).ToList();
                return cities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private List<CountryAPIModel> CountryList(string filePath)
        {
           // var filePath = HttpContext.Current.Server.MapPath("~/Data/country.json");
            var countries = JsonConvert.DeserializeObject<List<CountryAPIModel>>(File.ReadAllText(filePath));
            return countries;

        }

        private List<CityAPIModel> CityList(string filePath)
        {

            //var filePath = HttpContext.Current.Server.MapPath("~/Data/city.json");
            var Cities = JsonConvert.DeserializeObject<List<CityAPIModel>>(File.ReadAllText(filePath));
            return Cities;

        }

    }
}