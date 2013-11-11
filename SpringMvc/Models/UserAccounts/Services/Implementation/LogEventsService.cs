using SpringMvc.Models.UserAccounts.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;

namespace SpringMvc.Models.UserAccounts.Services.Implementation
{
    public class LogEventsService : BaseSpringService, ILogEventsService
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