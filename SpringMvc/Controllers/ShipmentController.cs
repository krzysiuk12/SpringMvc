using System;
using System.Collections.Generic;
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
            IEnumerable<Order> orders = ServiceLocator.ShipmentPreparationService.GetUnrealizedOrders();

            //Boolean result = ServiceLocator.MailingService.SendEmail("chamot@student.agh.edu.pl", "zam", "hejo");
            /*ViewBag.Orders = orders;
            ViewBag.Client = client;
            ViewBag.Order = order;
            ViewBag.OrderEntries = ServiceLocator.ShipmentPreparationService.GetOrderEntriesByOrderId(1);*/
            return View();
        }

        public ActionResult OrderDetails()
        {
            Order order = ServiceLocator.OrderInformationsService.GetOrderById(1);
            return View();
        }

        private void SetCurrentMenuPositions(int primaryMenuPosition, int? secondaryMenuPosition = null)
        {
            Session["PrimaryMenuPosition"] = primaryMenuPosition;
            Session["SecondaryMenuPosition"] = secondaryMenuPosition;
        }
    }
}