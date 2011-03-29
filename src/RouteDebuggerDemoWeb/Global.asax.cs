﻿using System;
using System.Web.Routing;
using System.Web.Mvc;
using System.Reflection;

namespace RouteTesterDemoWeb
{
    public class GlobalApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("foo-route", "foo/{id}", new { controller="Away", action = "Blah", id = (string)null });
            routes.MapRoute("bar-route", "bar/{id}", new { controller = "Home", action = "Index", id = (string)null });
            routes.MapRoute("token-route", "tokens/{id}", new {dataToken="BlahBlahBlah"});
            routes.MapRoute("extension", "ext/{id}.mvc", new { controller = "Home", action = "Index", id = (string)null });
            routes.MapRoute("mvc-default", "{controller}/{action}/{id}"
                , new { controller = "Home", action = "Index", id = (string)null });
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.RouteExistingFiles = true;
            RegisterRoutes(RouteTable.Routes);
            RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
        }
    }
}