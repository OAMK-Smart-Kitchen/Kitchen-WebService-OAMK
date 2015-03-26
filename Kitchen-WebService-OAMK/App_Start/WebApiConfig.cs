using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Kitchen_WebService_OAMK
{
    // Configuration of WEB API with Entity Framework
    // http://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework

    // One to Many with Fluent API 
    // http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx

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

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
