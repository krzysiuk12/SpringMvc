using SpringMvc.Models.UserAccounts.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Common.Interfaces
{
    public interface IDaoFactory
    {
        public IAuthorizationDao AuthorizationDao { get; set; }
        public IAccountAdministrationDao AccountAdministrationDao { get; set; }
        public ILogEventsDao LogEventsDao { get; set; }
        public IUserInformationDao UserInformationDao { get; set; }
    }
}
