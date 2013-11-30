using SpringMvc.Models.POCO;
using SpringMvc.Models.Invoices.Services.Interfaces;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SpringMvc.Models.Common;
using Spring.Transaction.Interceptor;
using Spring.Stereotype;
using System.Web.Mvc;

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
                totalOrderValue = Decimal.Add(totalOrderValue, Decimal.Multiply(entry.Price, (Decimal) entry.Amount));

            invoice.Vat = DaoFactory.CreateInvoiceDao.GetActualVat();
            invoice.VatPriceValue = Decimal.Multiply(totalOrderValue, invoice.Vat.Value);
            invoice.TotalValue = Decimal.Add(totalOrderValue, invoice.VatPriceValue);
            DaoFactory.CreateInvoiceDao.SaveInvoice(invoice);
        }
        [Transaction]
        public string GetInvoice(long orderId)
        {
            Order orderDetails = ServiceLocator.OrderInformationsService.GetOrderById(orderId);
            UserAccount userDetails = ServiceLocator.UserInformationService.GetUserAccountById(orderDetails.User.Id);
            Invoice invoice = DaoFactory.CreateInvoiceDao.GetInvoiceByOrderId(orderId);
            string invoiceName = PdfInvoiceBuilder.BuildInvoice(orderDetails, userDetails, invoice);
            invoice.Counter++;
            DaoFactory.CreateInvoiceDao.SaveInvoice(invoice);
            return invoiceName;
            
        }
    }
}