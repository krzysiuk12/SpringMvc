using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;

namespace SpringMvc.Models.UserAccounts.Dao.Implementation
{
    public class AccountAdministrationDao : BaseHibernateDao, IAccountAdministrationDao
    {
        public void SaveOrUpdateUser(UserAccount userAccount)
        {
            this.Session.SaveOrUpdate(userAccount);
        }

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