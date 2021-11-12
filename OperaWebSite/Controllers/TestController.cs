using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSite.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Login(string name, string role)
        {
            // El ViewBag se usa mucho para pasar datos del controlador a la vista
            ViewBag.Name = name;
            ViewBag.Role = role;
            return View();
        }

        public ActionResult SearchByTittle(string tittle)
        {
            ViewBag.Tittle = tittle;
            return View();
        }
    }
}