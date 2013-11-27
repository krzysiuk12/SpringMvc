using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SpringMvc.Models.Invoices.Services.Implementation;

namespace SpringMvc.Models.Invoices.Services.Interfaces
{
    public interface IPdfInvoiceBuilder
    {
       void BuildInvoice(Order orderDetails, UserAccount userDetails, Invoice invoice);
    }
}
