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
        private IApplicationInitializationService ApplicationInitializationService { get; set; }
        //
        // GET: /Start/

        public ActionResult Index()
        {
            ApplicationInitializationService.InitApplication();
            return RedirectToAction("Index", "Logging");
        }
    }
}
