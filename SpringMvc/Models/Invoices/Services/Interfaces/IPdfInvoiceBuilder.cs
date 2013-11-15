using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Invoices.Services.Interfaces
{
    public interface IPdfInvoiceBuilder
    {
       void BuildInvoice(Order orderDetails, UserAccount userDetails);
    }
}
