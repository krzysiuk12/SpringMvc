using SpringMvc.Models.UserAccounts.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Common.Interfaces
{
    public interface IServiceLocator
    {
        public IAuthorizationService AuthorizationService { get; set; }
        public IAccountAdministrationService AccountAdministrationService { get; set; }
        public ILogEventsService LogEventsService { get; set; }
        public IUserInformationService UserInformationService { get; set; }
    }
}
