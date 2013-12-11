using System;
using System.Collections;
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
        private IList<Order> orders;
        private Mock<IOrderManagementDao> orderManagementDaoMock;
        private Mock<IOrderInformationsDao> orderInformationDaoMock;
        [ClassInitialize]
        public static void Class_Initialize(TestContext testContext)
        {
           
        }

        [TestInitialize]
        public void Initialize()
        {
            order = new Order();
            order.OrderEntries = null;
            order.SentDate = DateTime.Now;
            order.Id = 10;
            order.User = null;
            userAcc = new UserAccount();
            userAcc.Id = 5;
            orders = new List<Order>();
            orderManagementDaoMock = _factory.CreateMock<IOrderManagementDao>();
            oms.OrderManagementDao = orderManagementDaoMock.MockObject;

        //    NMock.Actions.InvokeAction saveOrder = new NMock.Actions.InvokeAction(new Action(() => orders = new List<Order>(){order}));
          //  orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);

            orderInformationDaoMock = _factory.CreateMock<IOrderInformationsDao>();
            ois.OrderInformationDao = orderInformationDaoMock.MockObject;

            orderInformationDaoMock.Expects.Any.MethodWith<Order>(x => x.GetOrderById(order.Id)).WillReturn(order);
            orderInformationDaoMock.Expects.Any.MethodWith<Order>(x => x.GetOrderById(-1)).WillReturn(null);
           // orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetOrdersByUserId(userAcc.Id)).WillReturn(orders.Where(x => x.User.Id == userAcc.Id));
            orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetOrdersByUserId(-1)).WillReturn(orders.Where(x => x.User.Id == userAcc.Id));
            orderInformationDaoMock.Expects.Any.Method(x => x.GetUndeliveredOrders()).WillReturn(orders.Where(x => x.Status != Order.OrderState.DELIVERED));
            orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetUndeliveredByUserId(userAcc.Id)).WillReturn(orders.Where(x => x.Status != Order.OrderState.DELIVERED && x.User.Id == userAcc.Id));
            //orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetDeliveredOrdersByUserId(userAcc.Id)).WillReturn(orders.Where(x => x.Status == Order.OrderState.DELIVERED && x.User.Id == userAcc.Id));

        }



        [TestMethod]
        public void TestGetOrderById()
        {
            NMock.Actions.InvokeAction saveOrder = new NMock.Actions.InvokeAction(new Action(() => orders = new List<Order>() { order }));
            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);

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
            orders = new List<Order>();
            order.User = userAcc;
            NMock.Actions.InvokeAction saveOrder = new NMock.Actions.InvokeAction(new Action(() => orders.Add(order)));
            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);

            oms.CreateNewOrder(order);

            orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetOrdersByUserId(userAcc.Id)).WillReturn(orders.Where(x => x.User.Id == userAcc.Id));

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
            Assert.AreEqual((new LinkedList<Order>(orders)).Count, 0);
        }

        [TestMethod]
        public void TestGetUndeliveredOrders()
        {
            order.Status = Order.OrderState.ORDERED;
            NMock.Actions.InvokeAction saveOrder = new NMock.Actions.InvokeAction(new Action(() => orders.Add(order)));
            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);

            oms.CreateNewOrder(order);

            orderInformationDaoMock.Expects.Any.Method(x => x.GetUndeliveredOrders()).WillReturn(orders.Where(x => x.Status != Order.OrderState.DELIVERED));

            bool isOrderThere = false;
            foreach (var item in ois.GetUndeliveredOrders())
            {
                if (item.Status != Order.OrderState.DELIVERED) isOrderThere = true;
            }
            Assert.IsTrue(isOrderThere);
        }

        [TestMethod]
        public void TestGetUndeliveredOrdersByUserId()
        {
            order.User = userAcc;
            order.Status = Order.OrderState.ORDERED;
            NMock.Actions.InvokeAction saveOrder = new NMock.Actions.InvokeAction(new Action(() => orders.Add(order)));
            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);

            oms.CreateNewOrder(order);

            orderInformationDaoMock.Expects.Any.Method(x => x.GetUndeliveredOrders()).WillReturn(orders.Where(x => x.Status != Order.OrderState.DELIVERED && x.User.Id == userAcc.Id));

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
            order2.Status = Order.OrderState.DELIVERED;
            order2.OrderEntries = null;
            order2.SentDate = DateTime.Now;
            order2.Id = 10;
            userAcc.Id = 5;
            NMock.Actions.InvokeAction saveOrder = new NMock.Actions.InvokeAction(new Action(() => orders.Add(order2)));
            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order2)).Will(saveOrder);

            oms.SaveOrder(order2);

            orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetDeliveredOrdersByUserId(userAcc.Id)).WillReturn(orders.Where(x => x.Status == Order.OrderState.DELIVERED && x.User.Id == userAcc.Id));

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
