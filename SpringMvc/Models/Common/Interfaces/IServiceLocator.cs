using SpringMvc.Models.Invoices.Services.Interfaces;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Storehouse.Services.Interfaces;
using SpringMvc.Models.Suggestions.Services.Interfaces;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Common.Interfaces
{
    public interface IServiceLocator
    {
        IAuthorizationService AuthorizationService { get; set; }
        IAccountAdministrationService AccountAdministrationService { get; set; }
        ILogEventsService LogEventsService { get; set; }
        IUserInformationService UserInformationService { get; set; }
        ISuggestionService SuggestionService { get; set; }
        ICreateInvoiceService CreateInvoiceService { get; set; }
        IOrderInformationsService OrderInformationsService { get; set; }
        IOrderManagementService OrderManagementService { get; set; }
        IStorehouseManagementService StorehouseManagementService { get; set; }
        IBooksInformationService BooksInformationService { get; set; }
        ApplicationScope ApplicationScope { get; set; }
    }
}
