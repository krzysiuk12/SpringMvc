using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpringMvc.Models.Common;
using NHibernate;
using SpringMvc.Models.POCO;
using Spring.Context.Support;
using Spring.Context;
using Spring.Transaction;
using SpringMvc.Models;

namespace SpringMvc.Controllers
{
    public class HomeController : Controller
    {
        private IAddressService addressSaving;

        public IAddressService AddressSaving { get { return addressSaving; } set { this.addressSaving = value; } }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
