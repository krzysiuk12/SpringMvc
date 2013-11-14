using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using Spring.Objects.Factory.Config;
using SpringMvc.Models.Common.Services.Interfaces;
using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Common.Services.Implementation
{
    [Repository]
    public class ApplicationInitializationService : BaseSpringService, IApplicationInitializationService
    {
        private string AdministratorLogin { get { return "admin"; } }
        private string AdministratorPassword { get { return "admin";  } }
        private string WorkerLogin { get { return "worker";  } }
        private string WorkerPassword { get { return "worker"; } }

        [Transaction]
        public bool InitApplication()
        {
            CreateApplicationUsers();
            return true;
        }

        private void CreateApplicationUsers()
        {
            if (ServiceLocator.UserInformationService.GetUserAccountById(ApplicationScope.AdministratorId) == null) {
                UserAccount administrator = new UserAccount()
                {
                    Login = AdministratorLogin,
                    Password = AdministratorPassword,
                    ValidFrom = DateTime.MinValue,
                    ValidTo = DateTime.MaxValue,
                    AccountStatus = UserAccount.Status.ACTIVE
                };
                ServiceLocator.AccountAdministrationService.SaveOrUpdateUser(administrator);  // Administrator ID = 1;
            }

            if (ServiceLocator.UserInformationService.GetUserAccountById(ApplicationScope.WorkerId) == null) {
                UserAccount worker = new UserAccount()
                {
                    Login = WorkerLogin,
                    Password = WorkerPassword,
                    ValidFrom = DateTime.MinValue,
                    ValidTo = DateTime.MaxValue,
                    AccountStatus = UserAccount.Status.ACTIVE
                };
                ServiceLocator.AccountAdministrationService.SaveOrUpdateUser(worker); // Worker ID = 2
            }
        }
    }
}