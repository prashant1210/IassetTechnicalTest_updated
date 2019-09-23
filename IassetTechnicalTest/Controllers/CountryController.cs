using IassetTechnicalTest.Filter;
using IassetTechnicalTest.Models;
using IassetTechnicalTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IassetTechnicalTest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Api/Country")]
    public class CountryController : ApiController
    {
        private readonly ICountryServices _countryServices;
        public CountryController(ICountryServices countryServices)
        {
            _countryServices = countryServices;
        }
        [AllowCrossSiteAttribute]
        [HttpGet]
        [Route("GetCountries")]
        public HttpResponseMessage GetCountries()
        {
            try
            {
                
                return Request.CreateResponse(HttpStatusCode.OK, _countryServices.GetCountry(HttpContext.Current.Server.MapPath("~/Data/country.json")));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }


        [AllowCrossSiteAttribute]
        [HttpGet]
        [Route("GetCitiesByCountry")]
        public HttpResponseMessage GetCities(string countryCode)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _countryServices.GetCity(HttpContext.Current.Server.MapPath("~/Data/city.json"),countryCode));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

    }
}
