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


namespace SpringMvc.Models.UserAccounts.Services.Implementation
{
    [Repository]
    public class AuthorizationService : BaseSpringService, IAuthorizationService
    {
        [Transaction]
        public UserAccount LoginUser(string login, string password)
        {
            UserAccount user = DaoFactory.AuthorizationDao.LoginUser(login, password);
            if (user != null)
            {
                if (user.Password.Equals(EncryptPassword(password)))
                {
                    DaoFactory.LogEventsDao.SaveSuccessfulLogInEventForUser(user, HttpContext.Current.Request.UserHostAddress);
                }
                else
                {
                    DaoFactory.LogEventsDao.SaveFailedLogInEventForUser(user, HttpContext.Current.Request.UserHostAddress);
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
            return DaoFactory.AuthorizationDao.RegisterUser(newUserAccount);
        }

        [Transaction]
        public void SaveNewUserPersonalData(long userAccountId, PersonalData personalData, Address address)
        {
            UserAccount userAccount = ServiceLocator.UserInformationService.GetUserAccountById(userAccountId);
            userAccount.PersonalData = personalData;
            personalData.Address = address;
            ServiceLocator.AccountAdministrationService.SaveOrUpdateUser(userAccount);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<UserAccount> GetLoggedUserAccountsWithCriteria(IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public UserAccount LoggedUserAccount
        {
            [Transaction(ReadOnly = true)]
            get { throw new NotImplementedException(); }
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