using SpringMvc.Models.Common.Interfaces;
using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringMvc.Controllers
{
    public class ShipmentController : Controller
    {
        private IServiceLocator serviceLocator;
        //
        // GET: /Shipment/
        public ActionResult Index()
        {
            String[] orders = {"order1", "order2"};
            ViewBag.Orders = orders;
            return View();
        }

    }
}
