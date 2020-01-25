using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WS.UI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

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
