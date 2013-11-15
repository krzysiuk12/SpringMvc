using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Invoices.Dao.Interfaces
{
    public interface ICreateInvoiceDao
    {
        long SaveInvoice(Invoice newInvoice);
        long SaveVat(VatMap newVat);

    }
}
