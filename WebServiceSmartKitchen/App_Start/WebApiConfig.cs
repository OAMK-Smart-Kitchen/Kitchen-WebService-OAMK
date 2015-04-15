using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebServiceSmartKitchen
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var corsAttr = new EnableCorsAttribute("http://app.verhofstadt.eu, http://localhost:14844", "*", "*");
            config.EnableCors(corsAttr);
            // Web API JSON enabled
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; 
            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiActions",
            //    routeTemplate: "api/{controller}/Login",
            //    defaults: new { action = "Login" },
            //    constraints: null
            //);

            config.Routes.MapHttpRoute(
                name: "LoginToKitchen",
                routeTemplate: "service/Kitchen/Login",
                defaults: new { controller = "Kitchens", action = "Login" },
                constraints: null
            );

            config.Routes.MapHttpRoute(
                name: "RegisterNewKitche",
                routeTemplate: "service/Kitchen/Register",
                defaults: new { controller = "Kitchens", action = "Register" },
                constraints: null
            );

            config.Routes.MapHttpRoute(
                name: "RegisterNewMember",
                routeTemplate: "service/Member/Register",
                defaults: new { controller = "Members", action = "Register" },
                constraints: null
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
