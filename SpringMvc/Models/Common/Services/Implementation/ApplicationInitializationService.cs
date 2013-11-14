using Spring.Stereotype;
using Spring.Transaction.Interceptor;
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
        [Transaction]
        public void InitializeApplication()
        {
            CreateBaseUsers();
        }

        public void CreateBaseUsers() 
        {
            if(ServiceLocator.UserInformationService.GetUserAccountById(ApplicationScope.AdministratorId) == null) {
                UserAccount administratorAccont = new UserAccount()
                {
                    Login = ApplicationScope.AdministratorLogin,
                    Password = ApplicationScope.AdministratorPassword,
                    ValidFrom = DateTime.MinValue,
                    ValidTo = DateTime.MaxValue
                };
                ServiceLocator.AccountAdministrationService.SaveOrUpdateUser(administratorAccont);
            }

            if (ServiceLocator.UserInformationService.GetUserAccountById(ApplicationScope.WorkerId) == null)
            {
                UserAccount workerAccount = new UserAccount()
                {
                    Login = ApplicationScope.WorkerLogin,
                    Password = ApplicationScope.WorkerPassword,
                    ValidFrom = DateTime.MinValue,
                    ValidTo = DateTime.MaxValue
                };
                ServiceLocator.AccountAdministrationService.SaveOrUpdateUser(workerAccount);
            }
        }
    }
}