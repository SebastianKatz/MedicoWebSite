using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCClinica.Data
{
    public static class AdmMedico
    {
        private static DBMedicosContext context = new DBMedicosContext();
        public static List<Medico> listar() {
            var medicos = context.Medicos.ToList();
            return medicos;
        }
        public static void crear(Medico medico)
        {
            context.Medicos.Add(medico);
            context.SaveChanges();
        }
        public static Medico buscar(int id)
        {
            Medico medico = context.Medicos.Find(id);
            context.Entry(medico).State = EntityState.Detached;
            return medico;
        }
        public static void eliminar(Medico medico)
        {
            context.Medicos.Remove(medico);
            context.SaveChanges();
        }
        public static void modificar(Medico medico)
        {
            context.Medicos.Attach(medico);
            context.Entry(medico).State = EntityState.Modified;
            context.SaveChanges();
        }
        public static List<Medico> ListarEspecialidad(int especialidad)
        {
            List<Medico> medicosEspecialidad = (from o in context.Medicos
                                                where o.EspecialidadId == especialidad
                                                select o).ToList();
            return medicosEspecialidad;
        }
    }
}