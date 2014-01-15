using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;
using SpringMvc.Models.UserAccounts.Services.Implementation;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using SpringMvc.Tests.Models.UserAccounts;

namespace SpringMvc.Tests.Models.UserAccounts
{
    [TestClass]
    public class AccountManagementServiceTest
    {
        private IAccountManagementService managementService;
        private IAccountAdministrationService accountAdministrationService;
        private IUserInformationService userInformationService;
        private Helpers helper = new Helpers();
        private long userAccountId;
        private string newPassword = AuthorizationTestData.NEW_PASSWORD;
        private string oldPassword = AuthorizationTestData.PASSWORD;


        private Mock<IUserInformationService> userInformationServiceMock;
        private Mock<IAccountAdministrationDao> accountAdministrationDaoMock;
        private Mock<IAuthorizationService> authorizationServiceMock;
        private Mock<IAccountAdministrationService> accountAdministrationServiceMock;
        private Mock<IUserInformationDao> userInformationDaoMock;

        private MockFactory _factory = new MockFactory();
        private UserAccount userAccount = new UserAccount();

        [TestInitialize]
        public void Initialize()
        {
            managementService = new AccountManagementService();
            accountAdministrationService = new AccountAdministrationService();

            userInformationServiceMock = _factory.CreateMock<IUserInformationService>();
            accountAdministrationDaoMock = _factory.CreateMock<IAccountAdministrationDao>();
            authorizationServiceMock = _factory.CreateMock<IAuthorizationService>();
            accountAdministrationServiceMock = _factory.CreateMock<IAccountAdministrationService>();
            userInformationDaoMock = _factory.CreateMock<IUserInformationDao>();

            managementService.UserInformationDao = userInformationDaoMock.MockObject;
            userInformationService = userInformationServiceMock.MockObject;
            managementService.UserInformationService = userInformationService;
            managementService.AccountAdministrationDao = accountAdministrationDaoMock.MockObject;
            accountAdministrationService.AccountAdministrationDao = accountAdministrationDaoMock.MockObject;
            managementService.AuthorizationService = authorizationServiceMock.MockObject;
            managementService.AccountAdministrationService = accountAdministrationServiceMock.MockObject;
            helper.UserAccountHelper(userAccount);
            //accountAdministrationService.SaveOrUpdateUser(userAccount);
            userAccountId = userAccount.Id; 
        }
        [TestCleanup]
        public void After()
        {   
            managementService.RemoveUser(userAccountId);
        }

        [TestMethod]
        public void ChangePassword(){
            IList<UserAccount> accounts = new List<UserAccount>();
            NMock.Actions.InvokeAction saveUser = new NMock.Actions.InvokeAction(new Action(() => accounts.Add(userAccount)));
            accountAdministrationDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdateUser(userAccount)).Will(saveUser);
            accountAdministrationServiceMock.Expects.Any.MethodWith(x => x.SaveOrUpdateUser(userAccount)).Will(saveUser);
            
            userInformationServiceMock.Expects.Any.MethodWith(x => x.GetUserAccountById(userAccount.Id)).WillReturn(userAccount);
            userInformationDaoMock.Expects.Any.MethodWith(x => x.GetUserAccountById(userAccount.Id)).WillReturn(userAccount);
            
            authorizationServiceMock.Expects.Any.MethodWith(x => x.EncryptPassword(oldPassword)).WillReturn(oldPassword);
            authorizationServiceMock.Expects.Any.MethodWith(x => x.EncryptPassword(newPassword)).WillReturn(newPassword);

            managementService.ChangePassword(userAccountId, oldPassword, newPassword);
            UserAccount userAccount2 = userInformationService.GetUserAccountById(userAccountId);
            Assert.AreEqual(userAccount2.Password, newPassword);
        }

        [TestMethod]
        public void EditUserPersonalData()
        {
            IList<UserAccount> accounts = new List<UserAccount>();
            NMock.Actions.InvokeAction saveUser = new NMock.Actions.InvokeAction(new Action(() => accounts.Add(userAccount)));
            accountAdministrationDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdateUser(userAccount)).Will(saveUser);
            accountAdministrationServiceMock.Expects.Any.MethodWith(x => x.SaveOrUpdateUser(userAccount)).Will(saveUser);

            userInformationServiceMock.Expects.Any.MethodWith(x => x.GetUserAccountById(userAccount.Id)).WillReturn(userAccount);
            userInformationDaoMock.Expects.Any.MethodWith(x => x.GetUserAccountById(userAccount.Id)).WillReturn(userAccount);
            
            PersonalData testPersonalData = new PersonalData();
            testPersonalData.FirstName = AuthorizationTestData.EDIT_FIRST_NAME;
            testPersonalData.LastName = AuthorizationTestData.EDIT_LAST_NAME;
            testPersonalData.PESEL = AuthorizationTestData.EDIT_PESEL;
            testPersonalData.PhoneNumber = AuthorizationTestData.EDIT_PHONE_NUMBER;
            testPersonalData.Address = new Address();
            testPersonalData.Address.Street = AuthorizationTestData.EDIT_ADDRESS_STREET;
            testPersonalData.Address.PostalCode = AuthorizationTestData.EDIT_ADDRESS_POSTAL_CODE;
            testPersonalData.Address.City = AuthorizationTestData.EDIT_ADDRESS_CITY;
            testPersonalData.Address.Country = AuthorizationTestData.EDIT_ADDRESS_COUNTRY;

            managementService.EditUserPersonalData(userAccountId, testPersonalData);

            UserAccount userAccount2 = userInformationService.GetUserAccountById(userAccountId);
            PersonalData personalData = userAccount2.PersonalData;

            Assert.AreEqual(personalData.FirstName, testPersonalData.FirstName);
            Assert.AreEqual(personalData.LastName, testPersonalData.LastName);
            Assert.AreEqual(personalData.PESEL, testPersonalData.PESEL);
            Assert.AreEqual(personalData.PhoneNumber, testPersonalData.PhoneNumber);
            Assert.AreEqual(personalData.Address.Street, testPersonalData.Address.Street);
            Assert.AreEqual(personalData.Address.PostalCode, testPersonalData.Address.PostalCode);
            Assert.AreEqual(personalData.Address.City, testPersonalData.Address.City);
            Assert.AreEqual(personalData.Address.Country, testPersonalData.Address.Country);
        }
        [TestMethod]
        public void LockUser()
        {
            IList<UserAccount> accounts = new List<UserAccount>();
            NMock.Actions.InvokeAction saveUser = new NMock.Actions.InvokeAction(new Action(() => accounts.Add(userAccount)));
            accountAdministrationDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdateUser(userAccount)).Will(saveUser);
            accountAdministrationServiceMock.Expects.Any.MethodWith(x => x.SaveOrUpdateUser(userAccount)).Will(saveUser);
            
            userInformationServiceMock.Expects.Any.MethodWith(x => x.GetUserAccountById(userAccount.Id)).WillReturn(userAccount);
            userInformationDaoMock.Expects.Any.MethodWith(x => x.GetUserAccountById(userAccount.Id)).WillReturn(userAccount);
            
            managementService.LockUser(userAccountId);
            UserAccount userAccount2 = userInformationService.GetUserAccountById(userAccountId);
            Assert.AreEqual(userAccount2.AccountStatus, SpringMvc.Models.POCO.UserAccount.Status.LOCKED_OUT);
        }

        [TestMethod]
        public void RemoveUser()
        {
            IList<UserAccount> accounts = new List<UserAccount>();
            NMock.Actions.InvokeAction saveUser = new NMock.Actions.InvokeAction(new Action(() => accounts.Add(userAccount)));
            accountAdministrationDaoMock.Expects.Any.MethodWith(x => x.SaveOrUpdateUser(userAccount)).Will(saveUser);
            accountAdministrationServiceMock.Expects.Any.MethodWith(x => x.SaveOrUpdateUser(userAccount)).Will(saveUser);

            userInformationServiceMock.Expects.Any.MethodWith(x => x.GetUserAccountById(userAccount.Id)).WillReturn(userAccount);
            userInformationDaoMock.Expects.Any.MethodWith(x => x.GetUserAccountById(userAccount.Id)).WillReturn(userAccount);
            accounts.Add(userAccount);
            managementService.RemoveUser(userAccountId);
            UserAccount userAccount2 = userInformationService.GetUserAccountById(userAccountId);
            Assert.AreEqual(userAccount2.AccountStatus, SpringMvc.Models.POCO.UserAccount.Status.REMOVED);
        }

        

        
    }
    
}
