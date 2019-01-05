﻿using CMS.API.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CMS.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute(AppSettings.WebpageAddress, "*", "*");
            // Web API configuration and services
            config.EnableCors(cors);
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

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
