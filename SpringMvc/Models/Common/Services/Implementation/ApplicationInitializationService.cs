using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Common.Services.Interfaces;
using SpringMvc.Models.DataGenerator.Services.Interfaces;
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
        private IGeneratorService GeneratorService { get; set; }

        [Transaction]
        public void InitializeApplication()
        {
            CreateBaseUsers();
            List<BookType> bookTypes = GeneratorService.GenerateShopContent();
            List<UserAccount> userAccounts = GeneratorService.GenerateUsers();
            List<VatMap> vatValues = CreateVatStages();
			List<Order> orders = GeneratorService.GenerateOrders(bookTypes, userAccounts, vatValues);
			Console.WriteLine("");
        }

        public void CreateBaseUsers() 
        {
            if(ServiceLocator.UserInformationService.GetUserAccountById(ApplicationScope.AdministratorId) == null) {
                UserAccount administratorAccont = new UserAccount()
                {
                    Login = ApplicationScope.AdministratorLogin,
                    Password = ServiceLocator.AuthorizationService.EncryptPassword(ApplicationScope.AdministratorPassword),
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
                    Password = ServiceLocator.AuthorizationService.EncryptPassword(ApplicationScope.WorkerPassword),
                    ValidFrom = DateTime.MinValue,
                    ValidTo = DateTime.MaxValue
                };
                ServiceLocator.AccountAdministrationService.SaveOrUpdateUser(workerAccount);
            }
        }

		public List<VatMap> CreateVatStages()
		{
			double[] vatValues = new double[] { 0.05, 0.08, 0.23 };
			List<VatMap> vatMapValues = new List<VatMap>();
			for (int index = 0; index < vatValues.Length; index++)
			{
				VatMap newVat = new VatMap();
				newVat.Value = vatValues[index];
				vatMapValues.Add(newVat);
				DaoFactory.CreateInvoiceDao.SaveVat(newVat);
			}
			return vatMapValues;
		}
    }
}