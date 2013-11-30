using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Dao.Interfaces;
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
        private MockFactory _factory = new MockFactory();
        private IList<Order> orderLists;

        [ClassInitialize]
        public static void Class_Initialize(TestContext context)
        {
          //  userAcc = new UserAccount();
          //  aas.SaveOrUpdateUser(userAcc);
        }

        [TestInitialize]
        public void Initialize()
        {
            order = new Order();
            userAcc = new UserAccount();
            order.OrderEntries = null;
            order.SentDate = DateTime.Now;
            order.User = userAcc;
            order.Id = 1;
            
            orderLists = new List<Order>();

            var orderInformationsMock = _factory.CreateMock<IOrderInformationsDao>();
            ois.OrderInformationsDao = orderInformationsMock.MockObject;

            orderInformationsMock.Expects.One.MethodWith<Order>(x => x.GetOrderById(-1)).WillReturn(null);
            orderInformationsMock.Expects.One.MethodWith<Order>(x => x.GetOrderById(order.Id)).
                WillReturn(order);
            orderInformationsMock.Expects.One.MethodWith<IEnumerable<Order>>(x => x.GetOrdersByUserId(order.User.Id))
                .WillReturn(orderLists.Where<Order>(y => y.User.Id == userAcc.Id));
            orderInformationsMock.Expects.One.MethodWith<IEnumerable<Order>>(x => x.GetOrdersByUserId(-1))
                .WillReturn(orderLists.Where<Order>(y => y.User.Id == -1));
            orderInformationsMock.Expects.One.Method<IEnumerable<Order>>(x => x.GetUndeliveredOrders())
                .WillReturn(orderLists.Where<Order>(y => y.Status == Order.OrderState.ORDERED));
            orderInformationsMock.Expects.One.MethodWith<IEnumerable<Order>>(x => x.GetUndeliveredByUserId(order.User.Id))
               .WillReturn(orderLists.Where<Order>(y => y.Status == Order.OrderState.ORDERED && y.User.Id == userAcc.Id));
            orderInformationsMock.Expects.One.MethodWith<IEnumerable<Order>>(x => x.GetDeliveredOrdersByUserId(order.User.Id))
              .WillReturn(orderLists.Where<Order>(y => y.Status == Order.OrderState.DELIVERED && y.User.Id == userAcc.Id));
            

            var orderManagementMock = _factory.CreateMock<IOrderManagementDao>();
            oms.OrderManagementDao = orderManagementMock.MockObject;

            NMock.Actions.InvokeAction action = new NMock.Actions.InvokeAction(
                new Action(() => orderLists.Add(order)));
           
            orderManagementMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(
                    action
                );
        }


        [TestMethod]
        public void TestGetOrderById()
        {
            oms.CreateNewOrder(order);
            Order testedOrder = ois.GetOrderById(order.Id);
            Assert.AreEqual(testedOrder.Id, order.Id);
            Assert.IsNotNull(testedOrder);
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
            Assert.AreEqual(orders.Count(), 0);
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
            Order order2 = new Order();
            order2.User = userAcc;
            order2.Id = 5;
            order2.Status = Order.OrderState.DELIVERED;
            orderLists.Add(order2);
           // oms.CreateNewOrder(order2);
            bool isOrderThere = false;
            foreach (var item in ois.GetDeliveredOrdersByUserId(userAcc.Id))
            {
                Assert.AreEqual(item.User.Id, userAcc.Id);
                if (item.Id == order2.Id) isOrderThere = true;
            }
            Assert.IsTrue(isOrderThere);
        }
    }
}
