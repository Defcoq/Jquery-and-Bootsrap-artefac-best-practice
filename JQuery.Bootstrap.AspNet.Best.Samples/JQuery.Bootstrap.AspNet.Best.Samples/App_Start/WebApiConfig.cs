using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace JQuery.Bootstrap.AspNet.Best.Samples
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                 defaults: new { title = RouteParameter.Optional }
                //defaults: new { controller="Complete", action = "GetTitles", title = RouteParameter.Optional }
            );

            //MVC

        }
    }
}
