using MVCClinica.Data;
using MVCClinica.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCClinica.Controllers
{
    public class MedicoController : Controller
    {
        private static DBMedicosContext context = new DBMedicosContext();
        public ActionResult Index()
        {
            return View("Index", AdmMedico.listar());
        }

 
        public ActionResult Create()
        {
            Medico medico = new Medico();
            return View("Create", medico);
        }

        [FiltroGeneral]
        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                AdmMedico.crear(medico);
                return RedirectToAction("Index");
            }
            return View("Create", medico);
        }

        public ActionResult Detail(int id)
        {
            Medico medico = AdmMedico.buscar(id);
            if (medico != null)
            {
                return View("Detail", medico);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete(int id)
        {
            Medico medico = AdmMedico.buscar(id);
            if (medico != null)
            {
                return View("Delete", medico);
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
            Medico medico = AdmMedico.buscar(id);
            AdmMedico.eliminar(medico);
            return RedirectToAction("Index");
        }

        //GET /Opera/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Medico medico = AdmMedico.buscar(id);

            if (medico != null)
            {
                return View("Edit", medico);
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Medico medico)
        {
            if (ModelState.IsValid)
            {
                AdmMedico.modificar(medico);
                return RedirectToAction("Index");
            }
            return View("Edit", medico);
        }



        public ActionResult SearchByEspecialidad(int especialidad)
        {
            if (especialidad == 0)
                return RedirectToAction("Index");

            return View("Index", AdmMedico.ListarEspecialidad(especialidad));
        }


        public ActionResult IndexPorNombreApellido(string nombre, string apellido)
        {
            var medicos = (from m in context.Medicos where m.Nombre == nombre && m.Apellido == apellido select m).ToList();

            return View("Index", medicos);
        }

    }
}