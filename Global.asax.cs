using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;        // ★ 이거 추가됨
using MvcMovie2.Models;          // ★ 이거 추가됨 (Context 위치)
using MvcMovie2.App_Start;       // ★ FilterConfig 인식용

namespace MvcMovie2
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // ★ DB가 없거나 모델이 바뀌면 기존 DB를 날리고 새로 만듭니다. (Migration 안 씀)
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MovieListContext>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}