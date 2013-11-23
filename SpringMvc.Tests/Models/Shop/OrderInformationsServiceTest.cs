using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Implementation;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.UserAccounts.Services.Implementation;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
namespace SpringMvc.Tests.Models.Shop
{
    [TestClass]
    public class OrderInformationsServiceTest
    {
        private IOrderInformationsService ois = new OrderInformationsService();
        private IOrderManagementService oms = new OrderManagementService();
        private IAccountAdministrationService aas = new AccountAdministrationService();
        private Order order;
        private UserAccount userAcc;

        [ClassInitialize]
        public void Class_Initialize()
        {
            userAcc = new UserAccount();
            aas.SaveOrUpdateUser(userAcc);
        }

        [TestInitialize]
        public void Initialize()
        {
            order = new Order();
            order.OrderEntries = null;
            order.SentDate = DateTime.Now;
            order.User = null;
        }



        [TestMethod]
        public void TestGetOrderById()
        {
            oms.CreateNewOrder(order);
            Order testedOrder = ois.GetOrderById(order.Id);
            Assert.AreEqual(testedOrder.Id, order.Id);
        }

        [TestMethod]
        public void TestGetOrderByIdWithWrongId()
        {
            Order testedOrder = ois.GetOrderById(-1);
            Assert.IsNull(testedOrder);
        }

        [TestMethod]
        public void TestGetOrdersByUserId()
        {
            order.User = userAcc;
            oms.CreateNewOrder(order);
            bool isOrderThere = false;
            foreach (var item in ois.GetOrdersByUserId(userAcc.Id))
            {
                if (item.Id == order.Id) isOrderThere = true;
            }
            Assert.IsTrue(isOrderThere);
        }

        [TestMethod]
        public void TestGetOrdersByUserIdWithWrongId()
        {
            IEnumerable<Order> orders = ois.GetOrdersByUserId(-1);
            Assert.Equals((new LinkedList<Order>(orders)).Count, 0);
        }

        [TestMethod]
        public void TestGetUndeliveredOrders()
        {
            order.Status = Order.OrderState.ORDERED;
            oms.CreateNewOrder(order);
            bool isOrderThere = false;
            foreach (var item in ois.GetUndeliveredOrders())
            {
                if (item.Id == order.Id) isOrderThere = true;
            }
            Assert.IsTrue(isOrderThere);
        }

        [TestMethod]
        public void TestGetUndeliveredOrdersByUserId()
        {
            order.User = userAcc;
            order.Status = Order.OrderState.ORDERED;
            oms.CreateNewOrder(order);
            bool isOrderThere = false;
            foreach (var item in ois.GetUndeliveredOrdersByUserId(userAcc.Id))
            {
                Assert.AreEqual(item.User.Id, userAcc.Id);
                if (item.Id == order.Id) isOrderThere = true;
            }
            Assert.IsTrue(isOrderThere);
        }

        [TestMethod]
        public void TestGetDeliveredOrdersByUserId()
        {
            order.User = userAcc;
            order.Status = Order.OrderState.DELIVERED;
            oms.CreateNewOrder(order);
            bool isOrderThere = false;
            foreach (var item in ois.GetDeliveredOrdersByUserId(userAcc.Id))
            {
                Assert.AreEqual(item.User.Id, userAcc.Id);
                if (item.Id == order.Id) isOrderThere = true;
            }
            Assert.IsTrue(isOrderThere);
        }
    }
}
