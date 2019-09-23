using IassetTechnicalTest.Filter;
using IassetTechnicalTest.Models;
using IassetTechnicalTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IassetTechnicalTest.Controllers
{
    [RoutePrefix("Api/Weather")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherServices _weatherServices;
        public WeatherController(IWeatherServices weatherServices)
        {
            _weatherServices = weatherServices;
        }

        [AllowCrossSiteAttribute]
        [HttpGet]
        [Route("GetWeather")]
        public async Task<HttpResponseMessage> GetWeather(int cityId)
        {
            try
            {
                var result = await _weatherServices.GetWeatherDetails(cityId);
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, result);

                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [AllowCrossSiteAttribute]
        [HttpGet]
        [Route("GetWeatherByCityCountry")]
        public async Task<HttpResponseMessage> GetWeather(string cityName, string countryCode)
        {
            try
            {
                var result = await _weatherServices.GetWeatherDetails(cityName, countryCode);
                if (result != null)
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
