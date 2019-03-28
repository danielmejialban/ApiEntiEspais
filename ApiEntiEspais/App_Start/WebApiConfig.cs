using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiEntiEspais
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Reemplazamos el formateador y obligamos a utilizar JSON para la serialización de la API.
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
            Newtonsoft.Json.PreserveReferencesHandling.Objects;

            // Configuración y servicios de API web
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
