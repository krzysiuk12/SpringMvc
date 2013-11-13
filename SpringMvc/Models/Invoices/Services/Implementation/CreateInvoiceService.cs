using SpringMvc.Models.Invoices.Services.Interfaces;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.Common;
using Spring.Transaction.Interceptor;
using Spring.Stereotype;

namespace SpringMvc.Models.Invoices.Services.Implementation
{
    [Repository]
    public class CreateInvoiceService : BaseSpringService, ICreateInvoiceService
    {
        [Transaction(ReadOnly=true)]
        public void GetInvoice(long orderId)
        {
            
        }
    }
}