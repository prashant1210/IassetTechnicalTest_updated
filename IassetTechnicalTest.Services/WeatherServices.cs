using IassetTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace IassetTechnicalTest.Services
{
    public class WeatherServices : IWeatherServices
    {
        private readonly string _baseUrl = @"https://samples.openweathermap.org/data/2.5";
        private readonly string _weatherAPIKey = ConfigurationManager.AppSettings["WeatherAPIKey"];

        public async Task<WeatherModel> GetWeatherDetails(string cityName, string countryCode)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUrl);
                    HttpResponseMessage response = await client.GetAsync($"{_baseUrl}/weather?appid={_weatherAPIKey}&q={cityName},{countryCode}");
                    if (response.IsSuccessStatusCode)
                    {
                        Temperatures temperatures = await response.Content.ReadAsAsync<Temperatures>();
                        if (temperatures != null)
                        {
                            WeatherModel weather = new WeatherModel();
                            weather.DewPoint = "";
                            weather.Location = temperatures.Name;
                            weather.Pressure = temperatures.Main.Pressure.ToString();
                            weather.RelativeHumidity = temperatures.Main.Humidity.ToString();
                            weather.SkyConditions = "";
                            weather.Temperature = new { Min = temperatures.Main.TempMin, Max = temperatures.Main.TempMin };
                            weather.Time = UnixTimeStampToDateTime(temperatures.Dt).ToString();
                            weather.Visibility = temperatures.Visibility.ToString();
                            weather.Wind = new { Sepeed = temperatures.Wind.Speed , Deg = temperatures.Wind.Deg};
                            return weather;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<WeatherModel> GetWeatherDetails(int cityId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUrl);
                    HttpResponseMessage response = await client.GetAsync($"{_baseUrl}/weather?appid={_weatherAPIKey}&id={cityId}");
                    if (response.IsSuccessStatusCode)
                    {
                        Temperatures temperatures = await response.Content.ReadAsAsync<Temperatures>();
                        if (temperatures != null)
                        {
                            WeatherModel weather = new WeatherModel();
                            weather.DewPoint = "";
                            weather.Location = temperatures.Name;
                            weather.Pressure = temperatures.Main.Pressure.ToString();
                            weather.RelativeHumidity = temperatures.Main.Humidity.ToString();
                            weather.SkyConditions = "";
                            weather.Temperature = new { Min = temperatures.Main.TempMin, Max = temperatures.Main.TempMin };
                            weather.Time = UnixTimeStampToDateTime(temperatures.Dt).ToString();
                            weather.Visibility = temperatures.Visibility.ToString();
                            weather.Wind = new { Sepeed = temperatures.Wind.Speed, Deg = temperatures.Wind.Deg };
                            return weather;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


    }
}