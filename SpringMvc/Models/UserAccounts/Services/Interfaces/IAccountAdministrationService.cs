﻿using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.UserAccounts.Services.Interfaces
{
    public interface IAccountAdministrationService
    {
        void SaveOrUpdateUser(UserAccount userAccount);

        void RemoveUser(long userAccountId);

        void TurnOnUser(long userAccountId);

        void TurnOffUser(long userAccountId);

        void LockUser(long userAccountId);

        IEnumerable<UserAccount> GetUserAccountsWithCriteria(IDictionary<String, String> parameters);

        IEnumerable<UserAccount> AllUserAccounts { get; }

        IEnumerable<UserAccount> AllActiveUserAccounts { get; }
    }
}
