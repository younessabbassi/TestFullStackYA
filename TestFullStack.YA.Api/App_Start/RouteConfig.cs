﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestFullStack.YA.API
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         
            routes.MapRoute(
               name: "Users",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
           );

          /*  routes.MapRoute(
              name: "login",
              url: "{controller}/{action}/{*login}/{*password}",
              defaults: new { controller = "Users", action = "GetUserByLoginPass", login = "", password ="" }
            ); */
        }
    }
}
