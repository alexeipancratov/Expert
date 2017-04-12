using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Expert.WebApi.Infrastructure;

namespace Expert.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes(new CentralizedPrefixProvider("api"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var corsAttr = new EnableCorsAttribute("http://localhost:3000", "*", "*")
            {
                SupportsCredentials = true
            };

            config.EnableCors(corsAttr);
        }
    }
}
