using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Kitchen_WebService_OAMK
{
    // Configuration of WEB API with Entity Framework
    // http://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework

    // One to Many with Fluent API 
    // http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx

    // Create Models from excisting db
    // https://www.asp.net/mvc/overview/getting-started/database-first-development/creating-the-web-application

    // Enable Cors
    // http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable Cors
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors); 

            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Formatters.Clear();
            //config.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
