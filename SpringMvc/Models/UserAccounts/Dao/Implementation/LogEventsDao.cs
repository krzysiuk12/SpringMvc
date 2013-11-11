using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.UserAccounts.Dao.Implementation
{
    public class LogEventsDao : BaseHibernateDao, ILogEventsDao
    {
        public void SaveSuccessfulLogInEventForUser(UserAccount userAccountId, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public void SaveFailedLogInEventForUser(UserAccount userAccountId, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public void SaveLogOutEventForUser(UserAccount userAccountId, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogInOutEvent> GetLogEventsForUserByUserId(long userAccountId)
        {
            throw new NotImplementedException();
        }
    }
}