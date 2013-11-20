using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.Shipment.Services.Interfaces;
using SpringMvc.Models.Shipment.Services.Implementation;
using System.Collections.Generic;
using SpringMvc.Models.POCO;
namespace SpringMvc.Tests.Models.Shipment
{
    [TestClass]
    public class ShipmentPreperationServiceTest
    {
        private IShipmentPreparationService sps = new ShipmentPreparationService();
        [TestMethod]
        public void TestGetUnrealizedOrders()
        {
            IEnumerable<Order> orders = sps.GetUnrealizedOrders();
            foreach (var item in orders)
            {
                Assert.IsNotNull(item);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMarkOrderAsInProgressWithWrongId()
        {
            sps.MarkOrderAsInProgress(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCompleteOrderWithWrongId()
        {
            sps.CompleteOrder(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGetOrderEntriesByOrderIdWithWrongId()
        {
            sps.GetOrderEntriesByOrderId(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGetUserPersonalDataByIdWithWrongId()
        {
            sps.GetUserPersonalDataById(-1);
        }
    }
}
