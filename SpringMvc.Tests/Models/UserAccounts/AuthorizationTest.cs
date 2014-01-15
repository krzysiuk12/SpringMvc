using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using SpringMvc.Models.UserAccounts.Services.Implementation;
using SpringMvc.Models.POCO;
using NMock;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;

namespace SpringMvc.Tests.Models.UserAccounts
{
    [TestClass]
    public class AuthorizationTest
    {
        private IAuthorizationService authorizationService;
        private IAccountAdministrationService accountAdministrationService;
        private Helpers helper = new Helpers();
        private String login = AuthorizationTestData.LOGIN;
        private String password = AuthorizationTestData.PASSWORD;
        private String wrongPassword = AuthorizationTestData.WRONG_PASSWORD;
        private String login2 = "testLogin";
        private String password2 = "testPassword";

        private MockFactory _factory = new MockFactory();
        private Mock<IAccountAdministrationDao> accountAdministrationDaoMock;
        private Mock<IAuthorizationDao> authorizationDaoMock;
        private Mock<ILogEventsDao> logInOutEventDaoMock;

        private UserAccount userAccount = new UserAccount();
        [TestInitialize]
        public void Initialize()
        {
            authorizationService = new AuthorizationService();
            accountAdministrationService = new AccountAdministrationService();
          
            helper.UserAccountHelper(userAccount);

            accountAdministrationDaoMock = _factory.CreateMock<IAccountAdministrationDao>();
            authorizationDaoMock = _factory.CreateMock<IAuthorizationDao>();
            authorizationService.AuthorizationDao = authorizationDaoMock.MockObject;
            logInOutEventDaoMock = _factory.CreateMock<ILogEventsDao>();
            authorizationService.LogEventsDao = logInOutEventDaoMock.MockObject;
            //accountAdministrationService.SaveOrUpdateUser(userAccount);
        }

        [TestMethod]
        public void LogInWithWrongUserData()
        {
            authorizationDaoMock.Expects.Any.MethodWith(x => x.LoginUser(login, wrongPassword)).WillReturn(null);
            UserAccount user = authorizationService.LoginUser(login, wrongPassword);
            Assert.IsNull(user);
        }
        
        [TestMethod]
        public void LogInAsNormalUser()
        {
            logInOutEventDaoMock.Expects.Any.Method(x => x.SaveFailedLogInEventForUser(new UserAccount(), "localhost"));
            authorizationDaoMock.Expects.Any.MethodWith(x => x.LoginUser(login, password)).WillReturn(userAccount);
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
            Assert.AreEqual((new LinkedList<UserAccount>(LoggedAccounts)).Count, 2);
        }

    }
}
