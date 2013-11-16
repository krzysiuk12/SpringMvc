using SpringMvc.Models.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;
using SpringMvc.Models.Invoices.Dao.Interfaces;
using SpringMvc.Models.Shop.Dao.Interfaces;
using SpringMvc.Models.Storehouse.Dao.Interfaces;

namespace SpringMvc.Models.Common
{
    public class DaoFactory : IDaoFactory
    {
        public IAuthorizationDao AuthorizationDao { get; set; }

        public IAccountAdministrationDao AccountAdministrationDao { get; set; }

        public ILogEventsDao LogEventsDao { get; set; }

        public IUserInformationDao UserInformationDao { get; set; }

        public ICreateInvoiceDao CreateInvoiceDao { get; set; }

        public IOrderInformationsDao OrderInformationsDao { get; set; }

        public IOrderManagementDao OrderManagementDao { get; set; }

        public IBooksInformationDao BooksInformationDao { get; set; }
        
        public IStorehouseManagementDao StorehouseManagamentDao { get; set; }
    }
}