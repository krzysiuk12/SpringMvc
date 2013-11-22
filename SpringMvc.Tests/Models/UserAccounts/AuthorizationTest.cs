using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using SpringMvc.Models.UserAccounts.Services.Implementation;
using SpringMvc.Models.POCO;

namespace SpringMvc.Tests.Models.UserAccounts
{
    [TestClass]
    class AuthorizationTest
    {
        private IAuthorizationService authorizationService;
        private IAccountAdministrationService accountAdministrationService;
        private Helpers helper = new Helpers();
        private String login = AuthorizationTestData.LOGIN;
        private String password = AuthorizationTestData.PASSWORD;
        private String wrongPassword = AuthorizationTestData.WRONG_PASSWORD;
        private String login2= "testLogin";
        private String password2 = "testPassword";

        [TestInitialize]
        public void Initialize()
        {
            authorizationService = new AuthorizationService();
            accountAdministrationService = new AccountAdministrationService();
            UserAccount userAccount;
            userAccount = new UserAccount();
            helper.UserAccountHelper(userAccount);
            accountAdministrationService.SaveOrUpdateUser(userAccount);
        }

        [TestMethod]
        public void LogInWithWrongUserData(){
            UserAccount user = authorizationService.LoginUser(login, wrongPassword);
            Assert.IsNull(user);
        }
        [TestMethod]
        public void LogInAsNormalUser()
        {
            UserAccount user = authorizationService.LoginUser(login, password);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void LogOut()
        {
            UserAccount user = authorizationService.LoginUser(login, password);
            authorizationService.LogoutUser(login);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void CheckedLoggedAccount()
        {
            UserAccount user1 = authorizationService.LoginUser(login, password);
            Assert.IsNotNull(user1);
            UserAccount user2 = authorizationService.LoginUser(login2, password2);
            Assert.IsNotNull(user2);

            IEnumerable<UserAccount> LoggedAccounts = authorizationService.AllLoggedUserAccounts;
            Assert.Equals((new LinkedList<UserAccount>(LoggedAccounts)).Count, 2);
        }

    }
}
