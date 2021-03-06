﻿using SpringMvc.Models.Invoices.Dao.Interfaces;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;
using SpringMvc.Models.Shop.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.Storehouse.Dao.Interfaces;

namespace SpringMvc.Models.Common.Interfaces
{
    public interface IDaoFactory
    {
        IAuthorizationDao AuthorizationDao { get; set; }
        IAccountAdministrationDao AccountAdministrationDao { get; set; }
        ILogEventsDao LogEventsDao { get; set; }
        IUserInformationDao UserInformationDao { get; set; }
        ICreateInvoiceDao CreateInvoiceDao { get; set; }
        IOrderInformationsDao  OrderInformationsDao { get; set; }
        IOrderManagementDao OrderManagementDao { get; set; }
        IBooksInformationDao BooksInformationDao { get; set; }
        IStorehouseManagementDao StorehouseManagamentDao { get; set; }
    }
}
