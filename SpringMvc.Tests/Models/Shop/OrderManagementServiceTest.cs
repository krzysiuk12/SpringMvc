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

        [ClassInitialize]
        public void Initialize()
        {
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
        }

        [TestMethod]
        public void CreateNewOrderTestOrdered()
        {
            oms.CreateNewOrder(order);
            getOrder = ois.GetOrderById(order.Id);
            Assert.IsNotNull(getOrder.Status.Equals(Order.OrderState.ORDERED));
        }

        [TestMethod]
        public void MarkOrderSendTest()
        {
            oms.CreateNewOrder(order);
            oms.MarkOrderSent(order.Id);
            getOrder = ois.GetOrderById(order.Id);
            Assert.IsTrue(getOrder.Status.Equals(Order.OrderState.SENT));
        }

        [TestMethod]
        public void CompleteOrderTest()
        {
            oms.CreateNewOrder(order);
            oms.CompleteOrder(order.Id);
            getOrder = ois.GetOrderById(order.Id);
            Assert.IsTrue(getOrder.Status.Equals(Order.OrderState.DELIVERED));
        }

        [TestMethod]
        public void AddOrderEntryTest()
        {
            bool isInList = false;
            oms.CreateNewOrder(order);
            getOrder = ois.GetOrderById(order.Id);
            sms.SaveBookType(testBook);
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
            oms.CreateNewOrder(order);
            oms.SaveOrder(order);
            getOrder = ois.GetOrderById(order.Id);
            Assert.IsNotNull(getOrder);
        }

    }
}
