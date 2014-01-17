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
using System.Web;
using System.Security.Cryptography;

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

            userAccount.Password = Encrypt(userAccount.Password);
            
            logInOutEventDaoMock.Expects.Any.Method(x => x.SaveFailedLogInEventForUser(new UserAccount(), "localhost"));
            authorizationDaoMock.Expects.Any.MethodWith(x => x.LoginUser(login, password)).WillReturn(userAccount);
            authorizationService.AuthorizationDao = authorizationDaoMock.MockObject;
            authorizationService.LogEventsDao = logInOutEventDaoMock.MockObject;
            UserAccount user = authorizationService.LoginUser(login, password);
            Assert.IsNotNull(user);
        }

        private string Encrypt(string oldPass)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(oldPass));
            byte[] hashResult = sha.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < hashResult.Length; i++)
            {
                strBuilder.Append(hashResult[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        [TestMethod]
        public void LogOut()
        {
            logInOutEventDaoMock.Expects.Any.Method(x => x.SaveFailedLogInEventForUser(new UserAccount(), "localhost"));
            authorizationDaoMock.Expects.Any.MethodWith(x => x.LoginUser(login, password)).WillReturn(userAccount);
           
            UserAccount user = authorizationService.LoginUser(login, password);
            authorizationService.LogoutUser(login);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void CheckedLoggedAccount()
        {
            authorizationService.AuthorizationDao = authorizationDaoMock.MockObject;
            authorizationService.LogEventsDao = logInOutEventDaoMock.MockObject;

            UserAccount user1 = new UserAccount();
            user1.Password = password;
            user1.Login = login;
            Assert.IsNotNull(user1);
            UserAccount user2 = new UserAccount();
            user2.Password = password2;
            user2.Login = login2;
            Assert.IsNotNull(user2);

            user1.Password = Encrypt(user1.Password);
            user2.Password = Encrypt(user2.Password);

            List<UserAccount> loggedUsers = new List<UserAccount>();

            NMock.Actions.InvokeAction akcja2 = new NMock.Actions.InvokeAction( new Action( () => loggedUsers.Add(user2)));
            NMock.Actions.InvokeAction akcja = new NMock.Actions.InvokeAction(new Action(() => loggedUsers.Add(user1)));

            logInOutEventDaoMock.Expects.Any.Method(x => x.SaveFailedLogInEventForUser(new UserAccount(), "localhost"));
            authorizationDaoMock.Expects.Any.MethodWith(x => x.LoginUser(login, password)).Will(akcja, new NMock.Actions.ReturnAction<UserAccount>(user1)); // WillReturn(user1);
             
            logInOutEventDaoMock.Expects.Any.Method(x => x.SaveFailedLogInEventForUser(new UserAccount(), "localhost"));
            authorizationDaoMock.Expects.Any.MethodWith(x => x.LoginUser(login2, password2)).Will(akcja2, new NMock.Actions.ReturnAction<UserAccount>(user2)); // WillReturn(user2);

            authorizationService.LoginUser(login, password);
            authorizationService.LoginUser(login2, password2);

            authorizationDaoMock.Expects.Any.Method(x => x.GetLoggedUsers()).WillReturn(loggedUsers);
            
            IEnumerable<UserAccount> LoggedAccounts = authorizationService.AllLoggedUserAccounts;
            Assert.AreEqual((new LinkedList<UserAccount>(LoggedAccounts)).Count, 2);
        }

    }
}
