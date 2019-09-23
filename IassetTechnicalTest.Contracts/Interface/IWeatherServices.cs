using System.Threading.Tasks;
using IassetTechnicalTest.Models;

namespace IassetTechnicalTest.Services
{
    public interface IWeatherServices
    {
        Task<WeatherModel> GetWeatherDetails(int cityId);
        Task<WeatherModel> GetWeatherDetails(string cityName, string countryCode);
    }
}