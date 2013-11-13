using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.UserAccounts.Dao.Interfaces
{
    public interface IAuthorizationDao
    {
        UserAccount LoginUser(String login, String password);

        void LogoutUser(String login);

        long RegisterUser(UserAccount newUserAccount);

        IEnumerable<UserAccount> GetLoggedUserAccountsWithCriteria(IDictionary<String, String> parameters);

        UserAccount LoggedUserAccount { get; }

        IEnumerable<UserAccount> AllLoggedUserAccounts { get; }
    }
}
