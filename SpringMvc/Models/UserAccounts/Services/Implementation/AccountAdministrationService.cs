using SpringMvc.Models.UserAccounts.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;

namespace SpringMvc.Models.UserAccounts.Services.Implementation
{
    [Repository]
    public class AccountAdministrationService : BaseSpringService, IAccountAdministrationService
    {
        private IAccountAdministrationDao accountAdministrationDao;
        public IAccountAdministrationDao AccountAdministrationDao
        {
            set
            {
                accountAdministrationDao = value;
            }
            get
            {
                if (accountAdministrationDao == null)
                    return DaoFactory.AccountAdministrationDao;
                return accountAdministrationDao;
            }
        }

        private IUserInformationDao userInformationDao;
        public IUserInformationDao UserInformationDao
        {
            set
            {
                userInformationDao = value;
            }
            get
            {
                if (userInformationDao == null)
                    return DaoFactory.UserInformationDao;
                return userInformationDao;
            }
        }

        [Transaction]
        public void SaveOrUpdateUser(UserAccount userAccount)
        {
            AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }

        [Transaction]
        public void TurnOffUser(long userAccountId)
        {
            UserAccount userAccount = UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.AccountStatus = UserAccount.Status.OFF;
            AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }
    }
}