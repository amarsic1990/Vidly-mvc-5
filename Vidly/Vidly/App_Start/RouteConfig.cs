﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            // dodavanje custom route: dodajemo u route configu prije CUSTOM ROUTE
            // ovde je ordering vazan mormao ih definirati od najspecifičnijih prema generičkim
            //routes.MapRoute(
            //    name: "MoviesbyReleaseDate",
            //    url: "Movies/released/{year}/{month}",
            //    defaults: new {controller = "Movies", action = "ByReleaseDate" },
            //    //new { year = 2015 | 2016 ", month = @"\d{2}" }); --> ogranicavanje godine na 2016 ili 2016
            //    new { year = @"\d{4}", month = @"\d{2}"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
