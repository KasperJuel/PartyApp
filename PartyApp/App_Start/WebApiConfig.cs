using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PartyApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var setttings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            setttings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setttings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
