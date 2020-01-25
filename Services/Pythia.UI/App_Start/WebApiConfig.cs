using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Pythia.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //get config with mappings per module

            //loop through adding to the config route


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "PythiaApi/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Routes.MapHttpRoute(
            //    name: "Extended",
            //    routeTemplate: "PythiaApi/{controller}/{address}/{id}",
            //    defaults: new { address = RouteParameter.Optional, id = RouteParameter.Optional }
            //);
        }
    }
}
