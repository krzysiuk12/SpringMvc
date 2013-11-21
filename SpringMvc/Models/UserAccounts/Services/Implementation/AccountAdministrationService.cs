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
        public void TurnOffUser(long userAccountId)
        {
            UserAccount userAccount = DaoFactory.UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.AccountStatus = UserAccount.Status.OFF;
            DaoFactory.AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }
    }
}