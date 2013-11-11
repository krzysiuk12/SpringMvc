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
        public void AddNewUser(UserAccount userAccount)
        {
            userAccount.AccountStatus = UserAccount.Status.ACTIVE;
            userAccount.LastPasswordChangedDate = DateTime.Now;
            userAccount.ValidFrom = DateTime.Now;
            userAccount.ValidTo = new DateTime(userAccount.ValidFrom.Year + 1, userAccount.ValidFrom.Month, userAccount.ValidFrom.Day);
            DaoFactory.AccountAdministrationDao.AddNewUser(userAccount);
        }

        [Transaction]
        public void RemoveUser(long userAccountId)
        {
            throw new NotImplementedException();
        }

        [Transaction]
        public void TurnOnUser(long userAccountId)
        {
            throw new NotImplementedException();
        }

        [Transaction]
        public void TurnOffUser(long userAccountId)
        {
            throw new NotImplementedException();
        }

        [Transaction]
        public void LockUser(long userAccountId)
        {
            throw new NotImplementedException();
        }

        [Transaction]
        public void ChangePassword(long userAccountId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAccount> GetUserAccountsWithCriteria(IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAccount> AllUserAccounts
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<UserAccount> AllActiveUserAccounts
        {
            get { throw new NotImplementedException(); }
        }
    }
}