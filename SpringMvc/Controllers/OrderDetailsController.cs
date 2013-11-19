using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SpringMvc.Models.Common.Interfaces;
using SpringMvc.Models.POCO;

namespace SpringMvc.Controllers
{
    public class OrderDetailsController : Controller
    {
        private IServiceLocator ServiceLocator { get; set; }

        public ActionResult OrderDetails ()
        {
            Order order = ServiceLocator.OrderInformationsService.GetOrderById(1);
            return View();
        }
    }
}