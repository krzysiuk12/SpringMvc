using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.Shipment.Services.Interfaces;
using SpringMvc.Models.Shipment.Services.Implementation;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Shop.Services.Implementation;
using SpringMvc.Models.UserAccounts.Services.Implementation;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using System.Collections.Generic;
using SpringMvc.Models.POCO;
namespace SpringMvc.Tests.Models.Shipment
{
    //TESTY z withWrongID prawdopodobnie do usunięcia albo zmiany
    [TestClass]
    public class ShipmentPreperationServiceTest
    {
        private IShipmentPreparationService sps = new ShipmentPreparationService();
        private IOrderManagementService oms = new OrderManagementService();
        private IOrderInformationsService ois = new OrderInformationsService();
        private IAccountAdministrationService aas = new AccountAdministrationService();
        private Order order;
        private const string PESEL = "1234567890";
        private const PersonalData.Gender SEX = PersonalData.Gender.FEMALE;
        private const string firstName = "A";
        private const string lastName = "B";
        private const string IDCN = "a344";
        private const string PHONE = "333222333";
        [TestInitialize]
        public void Initialize()
        {
            order = new Order();
            order.OrderEntries = null;
            order.SentDate = DateTime.Now;
            order.User = null;
        }


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
        public void TestMarkOrderAsInProgress()
        {
            oms.CreateNewOrder(order);
            sps.MarkOrderAsInProgress(order.Id);
            Order testedOrder = ois.GetOrderById(order.Id);
            Assert.AreEqual(Order.OrderState.SENT, testedOrder.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMarkOrderAsInProgressWithWrongId()
        {
            sps.MarkOrderAsInProgress(-1);
        }

        [TestMethod]
        public void TestCompleteOrder()
        {
            oms.CreateNewOrder(order);
            sps.CompleteOrder(order.Id);
            Order testedOrder = ois.GetOrderById(order.Id);
            Assert.AreEqual(Order.OrderState.DELIVERED, testedOrder.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCompleteOrderWithWrongId()
        {
            sps.CompleteOrder(-1);
        }

        [TestMethod]
        public void TestGetOrderEntriesByOrderId()
        {
            OrderEntry tmpOrderEntry = new OrderEntry();
            order.OrderEntries.Add(tmpOrderEntry);
            oms.CreateNewOrder(order);
            bool isEntryThere = false;
            foreach (var item in sps.GetOrderEntriesByOrderId(order.Id))
            {
                if (item.Id == tmpOrderEntry.Id) isEntryThere = true;
            }
            Assert.IsTrue(isEntryThere);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGetOrderEntriesByOrderIdWithWrongId()
        {
            sps.GetOrderEntriesByOrderId(-1);
        }

        [TestMethod]
        public void TestIdentityCardNumber()
        {
            UserAccount userAcc = new UserAccount();
            PersonalData personalData = new PersonalData();
            personalData.PESEL = PESEL;
            personalData.Sex = SEX;
            personalData.FirstName = firstName;
            personalData.LastName = lastName;
            personalData.IdentityCardNumber = IDCN;
            personalData.PhoneNumber = PHONE;
            userAcc.PersonalData = personalData;
            aas.SaveOrUpdateUser(userAcc);
            PersonalData returnedPD = sps.GetUserPersonalDataById(userAcc.Id);
            Assert.AreEqual(PESEL, returnedPD.PESEL);
            Assert.AreEqual(SEX, returnedPD.Sex);
            Assert.AreEqual(firstName, returnedPD.FirstName);
            Assert.AreEqual(lastName, returnedPD.LastName);
            Assert.AreEqual(IDCN, returnedPD.IdentityCardNumber);
            Assert.AreEqual(PHONE, returnedPD.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestGetUserPersonalDataByIdWithWrongId()
        {
            sps.GetUserPersonalDataById(-1);
        }
    }
}
