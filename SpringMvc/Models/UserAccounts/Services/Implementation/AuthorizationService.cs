using SpringMvc.Models.UserAccounts.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;
using Spring.Transaction.Interceptor;
using Spring.Stereotype;
using System.Security.Cryptography;
using System.Text;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;


namespace SpringMvc.Models.UserAccounts.Services.Implementation
{
    [Repository]
    public class AuthorizationService : BaseSpringService, IAuthorizationService
    {
        private IAuthorizationDao authorizationDao;
        private ILogEventsDao logEventsDao;

        public IAuthorizationDao AuthorizationDao
        {
            get
            {
                if (authorizationDao == null)
                    return DaoFactory.AuthorizationDao;
                return authorizationDao;
            }
            set
            {
                authorizationDao = value;
            }
        }

        public ILogEventsDao LogEventsDao
        {
            get
            {
                if (logEventsDao == null)
                    return DaoFactory.LogEventsDao;
                return logEventsDao;
            }
            set
            {
                logEventsDao = value;
            }
        }

        [Transaction]
        public UserAccount LoginUser(string login, string password)
        {
            UserAccount user = AuthorizationDao.LoginUser(login, password);
            if (user != null)
            {
                if (user.Password.Equals(EncryptPassword(password)))
                {
                    LogEventsDao.SaveSuccessfulLogInEventForUser(user, HttpContext.Current.Request.UserHostAddress);
                }
                else
                {
                    LogEventsDao.SaveFailedLogInEventForUser(user, HttpContext.Current.Request.UserHostAddress);
                    return null;
                }
            }
            return user;
        }

        [Transaction]
        public void LogoutUser(string login)
        {
            throw new NotImplementedException();
        }

        [Transaction]
        public long RegisterUser(UserAccount newUserAccount)
        {
            if (validateUniqueLogin(newUserAccount.Login) == false)
            {
                return 0;
            }
            newUserAccount.Password = EncryptPassword(newUserAccount.Password);
            newUserAccount.AccountStatus = UserAccount.Status.ACTIVE;
            newUserAccount.LastPasswordChangedDate = DateTime.Now;
            newUserAccount.ValidFrom = DateTime.Now;
            newUserAccount.ValidTo = new DateTime(newUserAccount.ValidFrom.Year + 1, newUserAccount.ValidFrom.Month, newUserAccount.ValidFrom.Day);
            return AuthorizationDao.RegisterUser(newUserAccount);
        }

        [Transaction]
        public void SaveNewUserPersonalData(long userAccountId, PersonalData personalData, Address address)
        {
            UserAccount userAccount = ServiceLocator.UserInformationService.GetUserAccountById(userAccountId);
            userAccount.PersonalData = personalData;
            personalData.Address = address;
            ServiceLocator.AccountAdministrationService.SaveOrUpdateUser(userAccount);
        }

        public IEnumerable<UserAccount> AllLoggedUserAccounts
        {
            [Transaction(ReadOnly = true)]
            get { throw new NotImplementedException(); }
        }

        public string EncryptPassword(string text) {
            SHA256 sha = new SHA256CryptoServiceProvider();
            sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] hashResult = sha.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for(int i = 0; i < hashResult.Length; i++)
            {
                strBuilder.Append(hashResult[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        private bool validateUniqueLogin(String login)
        {
            IEnumerable<UserAccount> activeOrLockedUserAccounts = ServiceLocator.AccountManagementService.GetAllUserAccounts().Where(user => user.AccountStatus == UserAccount.Status.ACTIVE || user.AccountStatus == UserAccount.Status.LOCKED_OUT).ToList();
            return activeOrLockedUserAccounts.Where(user => user.Login.Equals(login)).ToList().Count == 0;
        }
    }
}