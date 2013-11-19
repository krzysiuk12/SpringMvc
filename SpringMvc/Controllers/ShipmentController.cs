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
            IEnumerable<Order> orders = ServiceLocator.ShipmentPreparationService.GetUnrealizedOrders();
            //String[] orders = { "order1", "order2" };
            //Boolean result = ServiceLocator.MailingService.SendEmail("chamot@student.agh.edu.pl", "zam", "hejo");
            //if (!result) throw new Exception();
            ViewBag.Orders = orders;
            ViewBag.Client = client;
            return View();
        }

        private void SetCurrentMenuPositions(int primaryMenuPosition, int? secondaryMenuPosition = null)
        {
            Session["PrimaryMenuPosition"] = primaryMenuPosition;
            Session["SecondaryMenuPosition"] = secondaryMenuPosition;
        }
    }
}