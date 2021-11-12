using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCClinica
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "IndexPorNombreApellido",
                url: "{controller}/{action}/{nombre}/{apellido}",
                defaults: new { controller = "Medico", action = "IndexPorNombreApellido" }
                );

            routes.MapRoute(
                name: "SearchByEspecialidad",
                url: "{controller}/traerEspecialidad/{especialidad}",
                defaults: new { controller = "Medico", action = "SearchByEspecialidad" }
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
