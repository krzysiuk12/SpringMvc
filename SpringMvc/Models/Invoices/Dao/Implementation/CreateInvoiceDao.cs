using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Invoices.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;

namespace SpringMvc.Models.Invoices.Dao.Implementation
{
    public class CreateInvoiceDao : BaseHibernateDao, ICreateInvoiceDao
    {
        public long SaveInvoice(Invoice newInvoice)
        {
            return (long)this.Session.Save(newInvoice);
        }

        public long SaveVat(VatMap newVat)
        {
            return (long)this.Session.Save(newVat);
        }

        public Invoice GetInvoiceByOrderId(long orderId)
        {
            return this.Session.Query<Invoice>().Where(invoice => invoice.Order.Id == orderId).Select(invoice => invoice).Single();
        }
    }
}
