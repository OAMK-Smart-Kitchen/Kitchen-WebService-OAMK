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
            var corsAttr = new EnableCorsAttribute("http://app.verhofstadt.eu, http://localhost:14844", "*", "*"); //Delete localhost when release
            config.EnableCors(corsAttr);
            // Web API JSON enabled
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; 
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "EditMember",
                routeTemplate: "service/Member/Profile/{id}",
                defaults: new { controller = "Members", action = "Update", id = RouteParameter.Optional },
                constraints: null
            );

            config.Routes.MapHttpRoute(
                name: "LoginToKitchen",
                routeTemplate: "service/Kitchen/Login",
                defaults: new { controller = "Kitchens", action = "Login" },
                constraints: null
            );

            config.Routes.MapHttpRoute(
                name: "RegisterNewKitchen",
                routeTemplate: "service/Kitchen/Register",
                defaults: new { controller = "Kitchens", action = "Register" },
                constraints: null
            );

            config.Routes.MapHttpRoute(
                name: "RegisterNewMember",
                routeTemplate: "service/Kitchen/Member/{id}",
                defaults: new { controller = "Kitchens", action = "Member", id = RouteParameter.Optional },
                constraints: null
            );

            config.Routes.MapHttpRoute(
                name: "SendFridgeProduct",
                routeTemplate: "service/Fridge/Product/{id}",
                defaults: new { controller = "ProductsFridges", action = "Addproduct", id = RouteParameter.Optional },
                constraints: null
            );

            config.Routes.MapHttpRoute(
                name: "EditFridgeProduct",
                routeTemplate: "service/Fridge/Product/Edit/{id}",
                defaults: new { controller = "ProductsFridges", action = "Editproduct", id = RouteParameter.Optional },
                constraints: null
            );

            config.Routes.MapHttpRoute(
                name: "AllFridgeProducts",
                routeTemplate: "service/Fridge/Products",
                defaults: new { controller = "ProductsFridges", action = "Getproducts" },
                constraints: null
            );

            config.Routes.MapHttpRoute(
                name: "AllFridgeProductsforHardware",
                routeTemplate: "service/Hardware/Products",
                defaults: new { controller = "ProductsFridges", action = "Getproducts" },
                constraints: null
            );

            config.Routes.MapHttpRoute(
                name: "PutFridgeProduct",
                routeTemplate: "service/Hardware/Product",
                defaults: new { controller = "ProductsFridges", action = "NFCproduct" },
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
