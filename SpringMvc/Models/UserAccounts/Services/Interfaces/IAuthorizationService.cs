using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;

namespace SpringMvc.Models.UserAccounts.Services.Interfaces
{
    public interface IAuthorizationService
    {
        IAuthorizationDao AuthorizationDao
        {
            get;
            set;
        }
        ILogEventsDao LogEventsDao
        {
            get;
            set;
        }

        UserAccount LoginUser(String login, String password);

        void LogoutUser(String login);

        long RegisterUser(UserAccount newUserAccount);

        void SaveNewUserPersonalData(long userAccountId, PersonalData personalData, Address address);

        string EncryptPassword(string text);

        IEnumerable<UserAccount> AllLoggedUserAccounts { get; }
    }
}
