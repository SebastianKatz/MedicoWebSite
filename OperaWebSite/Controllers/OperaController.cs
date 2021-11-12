using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperaWebSite.Models;
using OperaWebSite.Data;
using System.Data.Entity;
using System.Diagnostics;
using OperaWebSite.Filters;

namespace OperaWebSite.Controllers
{
    [MyFilterAction]
    public class OperaController : Controller
    {
        //Crear instancia del dbcontext
        private OperaDbContext context = new OperaDbContext();

        // GET: Opera o /Opera/Index
        public ActionResult Index()
        {
            var operas = context.Operas.ToList(); 
            return View("Index", operas);
        }

        public ActionResult Listar(string composer)
        {
            var operas = (from o in context.Operas
                          where o.Composer == composer
                          select o).ToList();
            return View("Index", operas);
        }

        [HttpGet] 
        public ActionResult Create()
        {
            Opera opera = new Opera(); 

            return View("Create", opera);
        }

        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("Create", opera);
        }


        // Opera/Detail/id
        public ActionResult Detail(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Detail", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }


        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Delete", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }


        //Opera/Delete
        [HttpPost] 

        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = context.Operas.Find(id);
            context.Operas.Remove(opera);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Edit", opera);
            }
            else
                return HttpNotFound();
        }


        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("Edit", opera);
        }
    }
}
