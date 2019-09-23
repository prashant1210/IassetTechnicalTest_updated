using System;
using System.Net.Http;
using System.Web.Http;
using IassetTechnicalTest.Controllers;
using IassetTechnicalTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IassetTechnicalTest.Tests
{
    [TestClass]
    public class CountryControllerTests
    {
        Mock<ICountryServices> _mockCountryService;

        public CountryControllerTests()
        {
            _mockCountryService = new Mock<ICountryServices>();
            _mockCountryService.Setup(c => c.GetCountry(It.IsAny<string>())).Returns(new System.Collections.Generic.List<Models.CountryModel>());
        }

        [TestMethod]
        public void GetCountriesTests()
        {
            CountryController controller = new CountryController(_mockCountryService.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var countries = controller.GetCountries();

            Assert.IsNotNull(countries);
        }

        [TestMethod]
        public void GetCitiesTests()
        {
            CountryController controller = new CountryController(_mockCountryService.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var cities = controller.GetCities("test");

            Assert.IsNotNull(cities);
        }
    }
}
