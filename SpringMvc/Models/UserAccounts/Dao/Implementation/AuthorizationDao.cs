using SpringMvc.Models.UserAccounts.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;
using NHibernate.Linq;

namespace SpringMvc.Models.UserAccounts.Dao.Implementation
{
    public class AuthorizationDao : BaseHibernateDao, IAuthorizationDao
    {
        public UserAccount LoginUser(string login, string password)
        {
            try
            {
                return this.Session.Query<UserAccount>().Where(user => user.Login == login).Select(user => user).Single();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public long RegisterUser(UserAccount newUserAccount)
        {
            return (long)this.Session.Save(newUserAccount);
        }

        public IEnumerable<UserAccount> GetLoggedUsers()
        {
            throw new NotImplementedException();
        }
    }
}