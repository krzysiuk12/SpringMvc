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
            //IEnumerable<Order> orders = ServiceLocator.ShipmentPreparationService.GetUnrealizedOrders();
            IList<Order> orders = new List<Order>();
            orders.Add(ServiceLocator.OrderInformationsService.GetOrderById(1));
            //Boolean result = ServiceLocator.MailingService.SendEmail("chamot@student.agh.edu.pl", "zam", "hejo");
            /*ViewBag.Orders = orders;
            ViewBag.Client = client;
            ViewBag.Order = order;
            ViewBag.OrderEntries = ServiceLocator.ShipmentPreparationService.GetOrderEntriesByOrderId(1);*/
            return View(orders);
        }

        public ActionResult OrderDetailsSite(long orderId)
        {
            Order order = ServiceLocator.OrderInformationsService.GetOrderById(orderId);
            return View(order);
        }

        private void SetCurrentMenuPositions(int primaryMenuPosition, int? secondaryMenuPosition = null)
        {
            Session["PrimaryMenuPosition"] = primaryMenuPosition;
            Session["SecondaryMenuPosition"] = secondaryMenuPosition;
        }
    }
}