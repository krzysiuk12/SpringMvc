﻿using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Invoices.Services.Interfaces
{
    public interface ICreateInvoiceService
    {
        void CreateNewInvoice(long orderId);
        string GetInvoice(long orderId);
    }
}