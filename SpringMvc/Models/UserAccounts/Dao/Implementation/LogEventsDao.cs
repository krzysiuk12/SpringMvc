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
    public class LogEventsDao : BaseHibernateDao, ILogEventsDao
    {
        public void SaveSuccessfulLogInEventForUser(UserAccount userAccount, string ipAddress)
        {
            this.Session.Save(new LogInOutEvent()
            {
                GeneratedOn = DateTime.Now,
                UserAccount = userAccount,
                IpAddress = ipAddress,
                Type = LogInOutEvent.ActionType.LOGIN_SUCCESSFUL
            });
        }

        public void SaveFailedLogInEventForUser(UserAccount userAccount, string ipAddress)
        {
            this.Session.Save(new LogInOutEvent()
            {
                GeneratedOn = DateTime.Now,
                UserAccount = userAccount,
                IpAddress = ipAddress,
                Type = LogInOutEvent.ActionType.LOGIN_FAILURE
            });
        }

        public void SaveLogOutEventForUser(UserAccount userAccount, string ipAddress)
        {
            this.Session.Save(new LogInOutEvent()
            {
                GeneratedOn = DateTime.Now,
                UserAccount = userAccount,
                IpAddress = ipAddress,
                Type = LogInOutEvent.ActionType.LOGOUT
            });
        }

        public IEnumerable<LogInOutEvent> GetLogEventsForUserByUserId(long userAccountId)
        {
            return this.Session.Query<LogInOutEvent>().Where(log => log.UserAccount.Id == userAccountId).Select(log => log).ToList();
        }
    }
}