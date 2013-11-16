using SpringMvc.Models.Common;
using SpringMvc.Models.Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringMvc.Controllers
{
    public class InitializationController : Controller
    {
        public IApplicationInitializationService ApplicationInitializationService { get; set; }
        //
        // GET: /Initialization/

        public ActionResult Index()
        {
            ApplicationInitializationService.InitializeApplication();
            HttpContext.Application["GuestId"] = (long)ApplicationScope.GuestId;
            HttpContext.Application["AdministratorId"] = (long)ApplicationScope.AdministratorId;
            HttpContext.Application["WorkerId"] = (long)ApplicationScope.WorkerId;
            return RedirectToAction("Index", "Logging");
        }

    }
}
