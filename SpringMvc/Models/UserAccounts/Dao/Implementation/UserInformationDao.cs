using SpringMvc.Models.Common;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using NHibernate.Linq;

namespace SpringMvc.Models.UserAccounts.Dao.Implementation
{
    public class UserInformationDao : BaseHibernateDao, IUserInformationDao
    {
        public UserAccount GetUserAccountById(long userAccountId)
        {
            return this.Session.Get(typeof(UserAccount), userAccountId) as UserAccount;
        }
    }
}
