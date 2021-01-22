﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GXXT
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            //忽略给定可用路由列表的指定url路由
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );
            //分页方法
            routes.MapRoute(
                "Paged", // Route name
                "{controller}/{action}/Page{pageIndex}", // URL with parameters
                new { controller = "RepairManger", action = "RepairManger" }, // Parameter defaults
                new { pageIndex = @"\d*" },
                new string[] { "Conris.JNNetworkMonitor.Controllers" }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // 默认情况下对 Entity Framework 使用 LocalDB
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}