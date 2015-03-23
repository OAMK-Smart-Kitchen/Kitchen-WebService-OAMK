using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Kitchen_WebService_OAMK
{
    // Configuration of WEB API with Entity Framework
    // http://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
