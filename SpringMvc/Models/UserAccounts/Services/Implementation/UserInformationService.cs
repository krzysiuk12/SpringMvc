using SpringMvc.Models.UserAccounts.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;
using Spring.Transaction.Interceptor;
using Spring.Stereotype;

namespace SpringMvc.Models.UserAccounts.Services.Implementation
{
    [Repository]
    public class UserInformationService : BaseSpringService, IUserInformationService
    {
        [Transaction(ReadOnly = true)]
        public UserAccount GetUserAccountById(long userAccountId)
        {
            return DaoFactory.UserInformationDao.GetUserAccountById(userAccountId);
        }
    }
}