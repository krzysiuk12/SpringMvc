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
        public void CreateNewInvoice(long orderId)
        {
            Invoice invoice = new Invoice();
            invoice.Counter = 0;
            invoice.Order = ServiceLocator.OrderInformationsService.GetOrderById(orderId);
            Decimal totalOrderValue = 0;
            
            foreach (OrderEntry entry in invoice.Order.OrderEntries)
                totalOrderValue += entry.Price;

            invoice.Vat = DaoFactory.CreateInvoiceDao.GetActualVat();
        }
        [Transaction]
        public void GetInvoice(long orderId)
        {
            Order orderDetails = ServiceLocator.OrderInformationsService.GetOrderById(orderId);
            UserAccount userDetails = ServiceLocator.UserInformationService.GetUserAccountById(orderDetails.User.Id);
            Invoice invoice = DaoFactory.CreateInvoiceDao.GetInvoiceByOrderId(orderId);
            PdfInvoiceBuilder.BuildInvoice(orderDetails, userDetails, invoice);
            invoice.Counter++;
            DaoFactory.CreateInvoiceDao.SaveInvoice(invoice);
        }
    }
}