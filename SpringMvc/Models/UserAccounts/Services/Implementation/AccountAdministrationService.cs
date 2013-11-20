using SpringMvc.Models.UserAccounts.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;

namespace SpringMvc.Models.UserAccounts.Services.Implementation
{
    [Repository]
    public class AccountAdministrationService : BaseSpringService, IAccountAdministrationService
    {
        [Transaction]
        public void SaveOrUpdateUser(UserAccount userAccount)
        {
            DaoFactory.AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }

        [Transaction]
        public void RemoveUser(long userAccountId)
        {
            UserAccount userAccount = DaoFactory.UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.AccountStatus = UserAccount.Status.REMOVED;
            DaoFactory.AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }

        [Transaction]
        public void TurnOnUser(long userAccountId)
        {
            UserAccount userAccount = DaoFactory.UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.AccountStatus = UserAccount.Status.ACTIVE;
            DaoFactory.AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }

        [Transaction]
        public void TurnOffUser(long userAccountId)
        {
            UserAccount userAccount = DaoFactory.UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.AccountStatus = UserAccount.Status.OFF;
            DaoFactory.AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }

        [Transaction]
        public void LockUser(long userAccountId)
        {
            UserAccount userAccount = DaoFactory.UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.AccountStatus = UserAccount.Status.LOCKED_OUT;
            DaoFactory.AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }

        [Transaction(ReadOnly=true)]
        public IEnumerable<UserAccount> GetUserAccountsWithCriteria(IDictionary<string, string> parameters)
        {
            return DaoFactory.AccountAdministrationDao.GetUserAccountsWithCriteria(parameters);
        }
        
        public IEnumerable<UserAccount> AllUserAccounts
        {
            [Transaction(ReadOnly = true)]
            get { return DaoFactory.AccountAdministrationDao.AllUserAccounts; }
        }

        public IEnumerable<UserAccount> AllActiveUserAccounts
        {
            [Transaction(ReadOnly = true)]
            get { return DaoFactory.AccountAdministrationDao.AllActiveUserAccounts; }
        }
    }
}