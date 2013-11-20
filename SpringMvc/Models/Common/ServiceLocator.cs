using SpringMvc.Models.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using SpringMvc.Models.Suggestions.Services.Interfaces;
using SpringMvc.Models.Invoices.Services.Interfaces;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Storehouse.Services.Interfaces;
using SpringMvc.Models.Shipment.Services.Interfaces;

namespace SpringMvc.Models.Common
{
    public class ServiceLocator : IServiceLocator
    {
        public IAuthorizationService AuthorizationService { get; set; }

        public IAccountAdministrationService AccountAdministrationService { get; set; }

        public IAccountManagementService AccountManagementService { get; set; }

        public ILogEventsService LogEventsService { get; set; }

        public IUserInformationService UserInformationService { get; set; }

        public ISuggestionService SuggestionService { get; set; }

        public ICreateInvoiceService CreateInvoiceService { get; set; }
        
        public IOrderInformationsService OrderInformationsService { get; set; }

        public IOrderManagementService OrderManagementService { get; set; }

        public IStorehouseManagementService StorehouseManagementService { get; set; }
        
        public IBooksInformationService BooksInformationService { get; set; }

        public IShipmentPreparationService ShipmentPreparationService { get; set; }

        public IMailingService MailingService { get; set; }
        
        public ApplicationScope ApplicationScope { get; set; }
    }
}