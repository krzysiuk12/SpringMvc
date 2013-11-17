using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpringMvc.Models.Common.Interfaces;
using SpringMvc.Models.POCO;

namespace SpringMvc.Controllers
{
    public class ShipmentController : Controller
    {
        private IServiceLocator ServiceLocator { get; set; }

        public ActionResult Index()
        {
            PersonalData client = ServiceLocator.ShipmentPreparationService.GetUserPersonalDataById(6);
            String[] orders = { "order1", "order2" };
            ViewBag.Orders = orders;
            ViewBag.Client = client;
            return View();
        }
    }
}