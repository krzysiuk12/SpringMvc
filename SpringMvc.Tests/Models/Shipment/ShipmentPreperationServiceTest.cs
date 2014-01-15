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
using NMock;
using SpringMvc.Models.Shop.Dao.Interfaces;
using System.Linq;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;
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

        private Mock<IOrderInformationsService> orderInformationServiceMock;
        private Mock<IOrderManagementService> orderManagementServiceMock;
        private Mock<IOrderManagementDao> orderManagementDaoMock;
        private Mock<IOrderInformationsDao> orderInformationsDaoMock;
        private Mock<IAccountAdministrationDao> accountAdministrationDao;
        private Mock<IUserInformationDao> userInformationDao;
        private Mock<IUserInformationService> userInformationService;
        private MockFactory _factory = new MockFactory();
        private IList<Order> orders;

        [TestInitialize]
        public void Initialize()
        {
            order = new Order();
            order.OrderEntries = new List<OrderEntry>();
            order.SentDate = DateTime.Now;
            order.User = null;

            orderInformationServiceMock = _factory.CreateMock<IOrderInformationsService>();
            orderManagementServiceMock = _factory.CreateMock<IOrderManagementService>();
            orderManagementDaoMock = _factory.CreateMock<IOrderManagementDao>();
            orderInformationsDaoMock = _factory.CreateMock<IOrderInformationsDao>();

            ois.OrderInformationDao = orderInformationsDaoMock.MockObject;
            oms.OrderManagementDao = orderManagementDaoMock.MockObject;
            oms.OrderInformationDao = orderInformationsDaoMock.MockObject;
            sps.OrderInformationsService = ois;
            sps.OrderManagementService = oms;

            accountAdministrationDao = _factory.CreateMock<IAccountAdministrationDao>();
            userInformationDao = _factory.CreateMock<IUserInformationDao>();
            aas.AccountAdministrationDao = accountAdministrationDao.MockObject;
            aas.UserInformationDao = userInformationDao.MockObject;
            
            userInformationService = _factory.CreateMock<IUserInformationService>();
            sps.UserInformationService = userInformationService.MockObject;
        }


        [TestMethod]
        public void TestGetUnrealizedOrders()
        {
            orders= new List<Order>();
            orders.Add(order);
            orderInformationsDaoMock.Expects.Any.Method(x => x.GetUndeliveredOrders())
                .WillReturn(orders.Where(x => x.Status != Order.OrderState.DELIVERED));
            IEnumerable<Order> getOrders = sps.GetUnrealizedOrders();
            foreach (var item in getOrders)
            {
                Assert.IsNotNull(item);
            }
        }

        [TestMethod]
        public void TestMarkOrderAsInProgress()
        {
            orders = new List<Order>();
            NMock.Actions.InvokeAction saveOrUpdateAction = new NMock.Actions.InvokeAction(() => orders.Add(order));
            orderManagementDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdate(order)).Will(saveOrUpdateAction);
            oms.CreateNewOrder(order);
            orderInformationsDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(order.Id)).WillReturn(orders.First(x => x.Id == order.Id));
            
            sps.MarkOrderAsInProgress(order.Id);
            Order testedOrder = ois.GetOrderById(order.Id);
            Assert.AreEqual(Order.OrderState.SENT, testedOrder.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMarkOrderAsInProgressWithWrongId()
        {
            orderInformationsDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(-1)).WillReturn(null);
            sps.MarkOrderAsInProgress(-1);
        }

        [TestMethod]
        public void TestCompleteOrder()
        {
            orders = new List<Order>();
            NMock.Actions.InvokeAction createOrder = new NMock.Actions.InvokeAction(() => orders.Add(order));
            orderManagementDaoMock.Expects.One.MethodWith(x => x.SaveOrUpdate(order)).Will(createOrder);
            oms.CreateNewOrder(order);
            orderInformationsDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(order.Id)).WillReturn(orders.First(x => x.Id == order.Id));
            orderManagementDaoMock.Expects.One.MethodWith(x => x.SaveOrUpdate(order)).Will(createOrder);
            sps.CompleteOrder(order.Id);
            Order testedOrder = ois.GetOrderById(order.Id);
            Assert.AreEqual(Order.OrderState.DELIVERED, testedOrder.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestCompleteOrderWithWrongId()
        {
            orderInformationsDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(-1)).WillReturn(null);
            sps.CompleteOrder(-1);
        }

        [TestMethod]
        public void TestGetOrderEntriesByOrderId()
        {
            OrderEntry tmpOrderEntry = new OrderEntry();
            order.OrderEntries.Add(tmpOrderEntry);
            orders = new List<Order>();
            NMock.Actions.InvokeAction createOrder = new NMock.Actions.InvokeAction(() => orders.Add(order));
            orderManagementDaoMock.Expects.One.MethodWith(x => x.SaveOrUpdate(order)).Will(createOrder);

            oms.CreateNewOrder(order); 
            orderInformationsDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(order.Id)).WillReturn(orders.FirstOrDefault(x => x.Id == order.Id));
           
            bool isEntryThere = false;
            foreach (var item in sps.GetOrderEntriesByOrderId(order.Id))
            {
                if (item.Id == tmpOrderEntry.Id) isEntryThere = true;
            }
            Assert.IsTrue(isEntryThere);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestGetOrderEntriesByOrderIdWithWrongId()
        {
            orderInformationsDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(-1)).WillReturn(null);
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
           
            List<UserAccount> userAccounts = new List<UserAccount>();
            NMock.Actions.InvokeAction addUserAccounts = new NMock.Actions.InvokeAction(() => userAccounts.Add(userAcc));
            accountAdministrationDao.Expects.One.MethodWith(x => x.SaveOrUpdateUser(userAcc)).Will(addUserAccounts);

            aas.SaveOrUpdateUser(userAcc);
            userInformationService.Expects.One.MethodWith(x => x.GetUserAccountById(userAcc.Id)).WillReturn(userAcc);
            PersonalData returnedPD = sps.GetUserPersonalDataById(userAcc.Id);
            Assert.AreEqual(PESEL, returnedPD.PESEL);
            Assert.AreEqual(SEX, returnedPD.Sex);
            Assert.AreEqual(firstName, returnedPD.FirstName);
            Assert.AreEqual(lastName, returnedPD.LastName);
            Assert.AreEqual(IDCN, returnedPD.IdentityCardNumber);
            Assert.AreEqual(PHONE, returnedPD.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestGetUserPersonalDataByIdWithWrongId()
        {
            userInformationService.Expects.Any.MethodWith(x => x.GetUserAccountById(-1)).WillReturn(null);
            orderInformationsDaoMock.Expects.Any.MethodWith(x => x.GetOrderById(-1)).WillReturn(null);
            sps.GetUserPersonalDataById(-1);
        }
    }
}
