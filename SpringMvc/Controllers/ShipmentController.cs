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
            IEnumerable<Order> orders = ServiceLocator.ShipmentPreparationService.GetUnrealizedOrders();
            return View(orders);
        }

        public ActionResult OrderDetailsSite(long orderId)
        {
            Order order = ServiceLocator.OrderInformationsService.GetOrderById(orderId);
            return View(order);
        }

        public ActionResult CompleteOrder(long orderId)
        {
            ServiceLocator.ShipmentPreparationService.CompleteOrder(orderId);
            return RedirectToAction("Index", "Shipment");
        }

        public ActionResult SendOrder(long orderId)
        {
            ServiceLocator.ShipmentPreparationService.MarkOrderAsInProgress(orderId);
            return RedirectToAction("Index", "Shipment");
        }

        private void SetCurrentMenuPositions(int primaryMenuPosition, int? secondaryMenuPosition = null)
        {
            Session["PrimaryMenuPosition"] = primaryMenuPosition;
            Session["SecondaryMenuPosition"] = secondaryMenuPosition;
        }
    }
}