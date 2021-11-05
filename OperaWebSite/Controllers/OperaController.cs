using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperaWebSite.Models;
using OperaWebSite.Data;
using System.Data.Entity;

namespace OperaWebSite.Controllers
{
    public class OperaController : Controller
    {
        // Crear instancia del DbContext

        private OperaDbContext context = new OperaDbContext();

        // GET: Opera o /Opera/Index
        public ActionResult Index()
        {
            // Traer todas las Operas usando EF
            var operas = context.Operas.ToList();
            // El controller retorna una vista "Index" con la lista de operas
            return View("Index", operas);
        }

        // Creamos dos metodos para la insercion de la opera en la DB

        // Primer create por GET para retornar la vista de registro

        [HttpGet] // El GET es implicito pero se puede esecificar
        public ActionResult Create()
        {
            Opera opera = new Opera();
            return View("Create", opera);
        }

        //Seg                                                                                                     undo Create es por POST para insertar la nueva opera en la base
        // cuando el usuario en la vista Create hace click en enviar

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

        public ActionResult Detail(int id)
        {
            Opera opera = context.Operas.Find(id);
            if(opera != null)
            {
                return View("Detail");
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

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Opera opera = context.Operas.Find(id);
            context.Operas.Remove(opera);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET /Opera/Edit/id
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