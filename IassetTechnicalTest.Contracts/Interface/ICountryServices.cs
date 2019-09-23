using System.Collections.Generic;
using IassetTechnicalTest.Models;

namespace IassetTechnicalTest.Services
{
    public interface ICountryServices
    {
        List<CityModel> GetCity(string path, string countryCode);
        List<CountryModel> GetCountry(string path);
    }
}