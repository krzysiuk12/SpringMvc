using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Invoices.Services.Interfaces
{
    interface IPdfInvoiceBuilder
    {
        void BuildInvoice(Order orderDetails, UserAccount userDetails);
    }
}
