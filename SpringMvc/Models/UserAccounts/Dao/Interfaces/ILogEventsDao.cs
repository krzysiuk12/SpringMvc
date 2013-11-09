using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.UserAccounts.Dao.Interfaces
{
    public interface ILogEventsDao
    {
        void SaveSuccessfulLogInEventForUser(UserAccount userAccountId, string ipAddress);

        void SaveFailedLogInEventForUser(UserAccount userAccountId, string ipAddress);

        void SaveLogOutEventForUser(UserAccount userAccountId, string ipAddress);

        IEnumerable<LogInOutEvent> GetLogEventsForUserByUserId(long userAccountId);
    }
}
