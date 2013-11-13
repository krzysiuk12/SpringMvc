﻿using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Invoices.Services.Interfaces
{
    public interface ICreateInvoiceService
    {
        Invoice GetInvoice(long orderId);
    }
}