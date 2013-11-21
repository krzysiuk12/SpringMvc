using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.UserAccounts.Dao.Interfaces
{
    public interface IAccountAdministrationDao
    {
        void SaveOrUpdateUser(UserAccount userAccount);

        IEnumerable<UserAccount> AllUserAccounts { get; }

        IEnumerable<UserAccount> AllActiveUserAccounts { get; }
    }
}
