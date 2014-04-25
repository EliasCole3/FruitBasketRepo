using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FruitBasketSimulator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //lols
            //routes.MapRoute(
            //name: null,
            //url: "OoodallaleeOooodahlalee{page}",
            //defaults: new { Controller = "Home", action = "ListRegisteredUsers" }
            //);

            //why doesn't this work the first time, for the first page?
            routes.MapRoute(
            name: null,
            url: "Page{page}",
            defaults: new { Controller = "Home", action = "ListRegisteredUsers" }
            );

            //211/193
            routes.MapRoute(
            name: null,
            url: "Page{page}",
            defaults: new { Controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } //This is what I want, opposed to listing something
            );
        }
    }
}