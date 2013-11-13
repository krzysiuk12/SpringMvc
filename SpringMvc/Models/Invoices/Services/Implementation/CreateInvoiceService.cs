using SpringMvc.Models.Invoices.Services.Interfaces;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Invoices.Services.Implementation
{
    public class CreateInvoiceService : ICreateInvoiceService, IUserInformationService
    {
        public void GetInvoice(long userAccountId);
    }
}