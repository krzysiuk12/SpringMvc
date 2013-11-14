using SpringMvc.Models.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using SpringMvc.Models.Suggestions.Services.Interfaces;

namespace SpringMvc.Models.Common
{
    public class ServiceLocator : IServiceLocator
    {
        public IAuthorizationService AuthorizationService { get; set; }

        public IAccountAdministrationService AccountAdministrationService { get; set; }

        public ILogEventsService LogEventsService { get; set; }

        public IUserInformationService UserInformationService { get; set; }

        public ISuggestionService SuggestionService { get; set; }

        public ApplicationScope ApplicationScope { get; set; }
    }
}