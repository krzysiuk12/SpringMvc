using SpringMvc.Models.UserAccounts.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;


namespace SpringMvc.Models.UserAccounts.Services.Implementation
{
    public class AuthorizationService : BaseSpringService, IAuthorizationService
    {
        public UserAccount LoginUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void LogoutUser(string login)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(UserAccount newUserAccount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAccount> GetLoggedUserAccountsWithCriteria(IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public UserAccount LoggedUserAccount
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<UserAccount> AllLoggedUserAccounts
        {
            get { throw new NotImplementedException(); }
        }
    }
}