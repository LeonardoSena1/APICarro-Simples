using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ApiCarros.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var httpClient = new HttpClient();

            return View();
        }
    }
}
