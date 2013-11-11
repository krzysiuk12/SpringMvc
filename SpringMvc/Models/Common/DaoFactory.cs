using SpringMvc.Models.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;

namespace SpringMvc.Models.Common
{
    public class DaoFactory : IDaoFactory
    {
        public IAuthorizationDao AuthorizationDao { get; set; }

        public IAccountAdministrationDao AccountAdministrationDao { get; set; }

        public ILogEventsDao LogEventsDao { get; set; }

        public IUserInformationDao UserInformationDao { get; set; }
    }
}