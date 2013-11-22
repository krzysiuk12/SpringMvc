using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.UserAccounts.Services.Implementation;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using SpringMvc.Tests.Models.UserAccounts;

namespace SpringMvc.Tests.Models.UserAccounts
{
    [TestClass]
    class AccountManagementServiceTest
    {
        private IAccountManagementService managementService;
        private IAccountAdministrationService accountAdministrationService;
        private IUserInformationService userInformationService;
        private Helpers helper = new Helpers();
        private long userAccountId;
        private string newPassword = AuthorizationTestData.NEW_PASSWORD;
        private string oldPassword = AuthorizationTestData.PASSWORD;
       
       
 
        [TestInitialize]
        public void Initialize()
        {
            managementService = new AccountManagementService();
            userInformationService = new UserInformationService();
            accountAdministrationService = new AccountAdministrationService();
            UserAccount userAccount;
            userAccount = new UserAccount();
            helper.UserAccountHelper(userAccount);
            accountAdministrationService.SaveOrUpdateUser(userAccount);
            userAccountId = userAccount.Id; 
        }
        [TestCleanup]
        public void After()
        {   
            managementService.RemoveUser(userAccountId);
        }

        [TestMethod]
        public void ChangePassword(){
            
            managementService.ChangePassword(userAccountId, oldPassword, newPassword);
            UserAccount userAccount = userInformationService.GetUserAccountById(userAccountId);
            Assert.Equals(userAccount.Password, newPassword);
        }

        [TestMethod]
        public void EditUserPersonalData()
        {
            PersonalData testPersonalData = new PersonalData();
            testPersonalData.FirstName = AuthorizationTestData.EDIT_FIRST_NAME;
            testPersonalData.LastName = AuthorizationTestData.EDIT_LAST_NAME;
            testPersonalData.PESEL = AuthorizationTestData.EDIT_PESEL;
            testPersonalData.PhoneNumber = AuthorizationTestData.EDIT_PHONE_NUMBER;
            testPersonalData.Address.Street = AuthorizationTestData.EDIT_ADDRESS_STREET;
            testPersonalData.Address.PostalCode = AuthorizationTestData.EDIT_ADDRESS_POSTAL_CODE;
            testPersonalData.Address.City = AuthorizationTestData.EDIT_ADDRESS_CITY;
            testPersonalData.Address.Country = AuthorizationTestData.EDIT_ADDRESS_COUNTRY;

            managementService.EditUserPersonalData(userAccountId, testPersonalData);

            UserAccount userAccount = userInformationService.GetUserAccountById(userAccountId);
            PersonalData personalData = userAccount.PersonalData;

            Assert.Equals(personalData.FirstName, testPersonalData.FirstName); 
            Assert.Equals(personalData.LastName, testPersonalData.LastName);
            Assert.Equals(personalData.PESEL, testPersonalData.PESEL);
            Assert.Equals(personalData.PhoneNumber, testPersonalData.PhoneNumber);
            Assert.Equals(personalData.Address.Street, testPersonalData.Address.Street);
            Assert.Equals(personalData.Address.PostalCode, testPersonalData.Address.PostalCode);
            Assert.Equals(personalData.Address.City, testPersonalData.Address.City);
            Assert.Equals(personalData.Address.Country, testPersonalData.Address.Country);
        }
        [TestMethod]
        public void LockUser()
        {
            managementService.LockUser(userAccountId);
            UserAccount userAccount = userInformationService.GetUserAccountById(userAccountId);
            Assert.Equals(userAccount.AccountStatus, SpringMvc.Models.POCO.UserAccount.Status.LOCKED_OUT);
        }

        [TestMethod]
        public void RemoveUser()
        {
                managementService.RemoveUser(userAccountId);
                UserAccount userAccount;
                Assert.IsNull(userAccount = userInformationService.GetUserAccountById(userAccountId));
        }

        

        
    }
    
}
