using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.UserAccounts.Services.Interfaces
{
    public interface IAuthorizationService
    {
        UserAccount LoginUser(String login, String password);

        void LogoutUser(String login);

        void RegisterUser(UserAccount newUserAccount);

        IEnumerable<UserAccount> GetLoggedUserAccountsWithCriteria(IDictionary<String, String> parameters);

        UserAccount LoggedUserAccount { get; }

        IEnumerable<UserAccount> AllLoggedUserAccounts { get; }
    }
}
