using SpringMvc.Models.POCO;
using SpringMvc.Models.Invoices.Services.Interfaces;
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
        private IPdfInvoiceBuilder PdfInvoiceBuilder { get; set; }

        [Transaction]
        public Invoice GetInvoice(long orderId)
        {

            Order orderDetails = null;
            UserAccount userDetails = ServiceLocator.UserInformationService.GetUserAccountById(orderDetails.User.Id);
            PdfInvoiceBuilder.BuildInvoice(orderDetails, userDetails);
             
            throw new NotImplementedException();
        }
    }
}