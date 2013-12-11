using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;

namespace SpringMvc.Models.UserAccounts.Services.Interfaces
{
    public interface IAccountAdministrationService
    {
        IAccountAdministrationDao AccountAdministrationDao
        {
            get;
            set;
        }
        IUserInformationDao UserInformationDao
        {
            get;
            set;
        }
        void SaveOrUpdateUser(UserAccount userAccount);

        void TurnOffUser(long userAccountId);
    }
}
