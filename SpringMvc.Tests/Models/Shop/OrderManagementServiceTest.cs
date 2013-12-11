using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Shop.Services.Implementation;
using SpringMvc.Models.Storehouse.Services.Interfaces;
using SpringMvc.Models.Storehouse.Services.Implementation;
using NMock;
using SpringMvc.Models.Shop.Dao.Interfaces;
using SpringMvc.Models.Storehouse.Dao.Interfaces;

namespace SpringMvc.Tests.Models.Shop
{
    [TestClass]
    public class OrderManagementServiceTest
    {
        private Order order;
        private Order getOrder;
        private IOrderManagementService oms = new OrderManagementService();
        private IOrderInformationsService ois = new OrderInformationsService();
        private IStorehouseManagementService sms = new StorehouseManagementService();
        private BookType testBook;
        private int TEST_AMOUNT;

        private Mock<IOrderManagementDao> orderManagementDaoMock;
        private Mock<IOrderInformationsDao> orderInformationDaoMock;
        private Mock<IStorehouseManagementDao> storehouseManagementDaoMock;
        private Mock<IBooksInformationService> booksInformationServiceMock;
        private MockFactory _factory;

        [TestInitialize]
        public void Initialize()
        {
            _factory = new MockFactory();
            order = new Order();
            order.OrderEntries = null;
            order.SentDate = DateTime.Now;
            order.User = null;
            getOrder = new Order();
            testBook = new BookType();
            Category testCategory = new Category();
            testBook.Id = 47123;
            testBook.Title = "Książka testowa";
            testBook.Authors = "Autor testowy";
            testBook.Category = testCategory;
            testBook.Price = 40;
            TEST_AMOUNT = 5;

            orderManagementDaoMock = _factory.CreateMock<IOrderManagementDao>();
            oms.OrderManagementDao = orderManagementDaoMock.MockObject;

            orderInformationDaoMock = _factory.CreateMock<IOrderInformationsDao>();
            ois.OrderInformationDao = orderInformationDaoMock.MockObject;
            oms.OrderInformationDao = orderInformationDaoMock.MockObject;

            storehouseManagementDaoMock = _factory.CreateMock<IStorehouseManagementDao>();
            sms.StorehouseManagementDao = storehouseManagementDaoMock.MockObject;

            booksInformationServiceMock = _factory.CreateMock<IBooksInformationService>();
            sms.BooksInformationService = booksInformationServiceMock.MockObject;
            oms.BooksInformationService = booksInformationServiceMock.MockObject;
        }

        [TestMethod]
        public void CreateNewOrderTestOrdered()
        {
            NMock.Actions.InvokeAction saveOrder = new NMock.Actions.InvokeAction(
            new Action(() => getOrder = order));

            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);
            orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(order.Id)).WillReturn(getOrder);
            oms.CreateNewOrder(order);
            getOrder = ois.GetOrderById(order.Id);
            Assert.IsNotNull(getOrder.Status.Equals(Order.OrderState.ORDERED));
        }

        [TestMethod]
        public void MarkOrderSendTest()
        {
            NMock.Actions.InvokeAction saveOrder = new NMock.Actions.InvokeAction(
           new Action(() => getOrder = order));

            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);
            orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(order.Id)).WillReturn(getOrder);
            orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(order.Id)).WillReturn(getOrder);
            
            oms.CreateNewOrder(order);
            orderManagementDaoMock.Expects.One.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);
           
            oms.MarkOrderSent(order.Id);
            getOrder = ois.GetOrderById(order.Id);
            Assert.IsTrue(getOrder.Status.Equals(Order.OrderState.SENT));
        }

        [TestMethod]
        public void CompleteOrderTest()
        {
            NMock.Actions.InvokeAction saveOrder = new NMock.Actions.InvokeAction(
          new Action(() => getOrder = order));

            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);
            orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(order.Id)).WillReturn(getOrder);
            orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(order.Id)).WillReturn(getOrder);
            
            oms.CreateNewOrder(order);
            oms.CompleteOrder(order.Id);
            orderManagementDaoMock.Expects.One.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);
           
            getOrder = ois.GetOrderById(order.Id);
            Assert.IsTrue(getOrder.Status.Equals(Order.OrderState.DELIVERED));
        }

        [TestMethod]
        public void AddOrderEntryTest()
        {

            List<Order> orders = new List<Order>();
            List<BookType> bookTypeList = new List<BookType>();
            NMock.Actions.InvokeAction saveOrUpdateAction = new NMock.Actions.InvokeAction(() => orders.Add(order));
            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrUpdateAction);
            
            bool isInList = false;
            order.OrderEntries = new List<OrderEntry>();
            oms.CreateNewOrder(order);
            orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(order.Id)).WillReturn(orders.First(x => x.Id == order.Id));
            
            getOrder = ois.GetOrderById(order.Id);

            NMock.Actions.InvokeAction saveBookType = new NMock.Actions.InvokeAction(new Action(() => bookTypeList.Add(testBook)));
            storehouseManagementDaoMock.Expects.Any.MethodWith(x => x.SaveBookType(testBook)).Will(saveBookType);

            sms.SaveBookType(testBook);
            booksInformationServiceMock.Expects.Any.MethodWith(x => x.GetBookTypeById(testBook.Id)).WillReturn(bookTypeList.FirstOrDefault(x => x.Id == testBook.Id));
            
            oms.AddOrderEntry(order, testBook.Id, TEST_AMOUNT);

            foreach (var item in order.OrderEntries)
            {
                if (item.Amount.Equals(TEST_AMOUNT) &&
                    item.BookType.Equals(testBook) &&
                    item.Price.Equals(testBook.Price)) isInList = true;
            };

            Assert.IsTrue(isInList);
        }


        [TestMethod]
        public void SaveOrderTest()
        {
            NMock.Actions.InvokeAction saveOrder = new NMock.Actions.InvokeAction(
        new Action(() => getOrder = order));

            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);
            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrder);
            orderInformationDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(order.Id)).WillReturn(getOrder);
            
            oms.CreateNewOrder(order);
            oms.SaveOrder(order);
            getOrder = ois.GetOrderById(order.Id);
            Assert.IsNotNull(getOrder);
        }

    }
}
