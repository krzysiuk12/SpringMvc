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

        public IEnumerable<UserAccount> AllUserAccounts
        {
            get { return this.Session.Query<UserAccount>().Where(user => user.Id > 2).OrderBy(user => user.Id).ToList(); }
        }

        public IEnumerable<UserAccount> AllActiveUserAccounts
        {
            get { return this.Session.Query<UserAccount>().Where(user => user.Id > 2 && user.AccountStatus == UserAccount.Status.ACTIVE).OrderBy(user => user.Id).ToList(); }
        }
    }
}