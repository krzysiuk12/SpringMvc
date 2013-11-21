using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Spring.Web.Mvc;
using SpringMvc.Config;
using Spring.Context.Support;
using Spring.Context;
using SpringMvc.Models.Common;

namespace SpringMvc
{
    public class MvcApplication : SpringMvcApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            Application["Guest"] = ApplicationScope.GuestId;
            Application["AdministratorId"] = ApplicationScope.AdministratorId;
            Application["WorkerId"] = ApplicationScope.WorkerId;
        }

        void Application_Error(object sender, EventArgs e)
        {

            Exception exc = Server.GetLastError();


            Response.Write("<h2>ERROR PAGE</h2>\n");
            Response.Write(
                "<p>" + exc.Message + "</p>\n");
            Response.Write("Return to the <a href='/'>" +
                "MainShop</a>\n");

            Server.ClearError();
        }
    }
}