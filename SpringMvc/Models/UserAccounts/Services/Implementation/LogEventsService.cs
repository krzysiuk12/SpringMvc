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
    public class LogEventsService : BaseSpringService, ILogEventsService
    {
        [Transaction]
        public void SaveSuccessfulLogInEventForUser(UserAccount userAccountId, string ipAddress)
        {
            throw new NotImplementedException();
        }

        [Transaction]
        public void SaveFailedLogInEventForUser(UserAccount userAccountId, string ipAddress)
        {
            throw new NotImplementedException();
        }

        [Transaction]
        public void SaveLogOutEventForUser(UserAccount userAccountId, string ipAddress)
        {
            throw new NotImplementedException();
        }

        [Transaction]
        public void SaveLogInOutEvent(LogInOutEvent logEvent)
        {
            DaoFactory.LogEventsDao.SaveLogInOutEvent(logEvent);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<LogInOutEvent> GetLogEventsForUserByUserId(long userAccountId)
        {
            throw new NotImplementedException();
        }
    }
}