using OperaWebSite.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [MyFilterAction]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

    }
}