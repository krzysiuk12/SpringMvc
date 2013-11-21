using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.UserAccounts.Services.Interfaces
{
    public interface IAccountManagementService
    {
        void EditUserPersonalData(long userId, PersonalData personalData);

        void ChangePassword(long userAccountId, string oldPassword, string newPassword);

        void ChangeUserPassword(long userId, String newPassword);

        IEnumerable<UserAccount> GetAllUserAccounts();

        IEnumerable<UserAccount> GetAllActiveUserAccounts();

        void RemoveUser(long userAccountId);

        void LockUser(long userAccountId);

        void TurnOnUser(long userAccountId);
    }
}
