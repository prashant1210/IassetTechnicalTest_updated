using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace IassetTechnicalTest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        public string Index()
        {

            return "OK";
        }
    }
}
