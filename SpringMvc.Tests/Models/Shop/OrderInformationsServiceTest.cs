using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Implementation;
using SpringMvc.Models.Shop.Services.Interfaces;

namespace SpringMvc.Tests.Models.Shop
{
    [TestClass]
    public class OrderInformationsServiceTest
    {
        private IOrderInformationsService ois = new OrderInformationsService();
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGetOrderByIdWithWrongId()
        {
            ois.GetOrderById(-1);
        }

        [TestMethod]
        public void TestGetOrdersByUserIdWithWrongId()
        {
            IEnumerable<Order> orders = ois.GetOrdersByUserId(-1);
            Assert.Equals((new LinkedList<Order>(orders)).Count, 0);
        }

        [TestMethod]
        public void TestGetInProgressOrdersByUserIdWithWrongId()
        {
            IEnumerable<Order> orders = ois.GetInProgressOrdersByUserId(-1);
            Assert.Equals((new LinkedList<Order>(orders)).Count, 0);
        }

        [TestMethod]
        public void TestGetInProgressOrders()
        {
            IEnumerable<Order> orders = ois.GetInProgressOrders();
            foreach (var item in orders)
            {
                Assert.IsNotNull(item);
            }
        }
    }
}
