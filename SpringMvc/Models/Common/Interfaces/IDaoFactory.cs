using SpringMvc.Models.Invoices.Dao.Interfaces;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Common.Interfaces
{
    public interface IDaoFactory
    {
        IAuthorizationDao AuthorizationDao { get; set; }
        IAccountAdministrationDao AccountAdministrationDao { get; set; }
        ILogEventsDao LogEventsDao { get; set; }
        IUserInformationDao UserInformationDao { get; set; }
        ICreateInvoiceDao CreateInvoiceDao { get; set; }
    }
}
