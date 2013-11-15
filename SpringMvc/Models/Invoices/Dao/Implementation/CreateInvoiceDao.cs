using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Invoices.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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


    }
}
