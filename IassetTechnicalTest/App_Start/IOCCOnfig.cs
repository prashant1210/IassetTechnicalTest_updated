using IassetTechnicalTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace IassetTechnicalTest
{
    public class IOCConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<ICountryServices, CountryServices>();
            container.RegisterType<IWeatherServices, WeatherServices>();

            DependencyResolver.SetResolver(new  UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}