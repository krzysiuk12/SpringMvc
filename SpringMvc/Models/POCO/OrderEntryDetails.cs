using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class OrderEntryDetails
    {
        long ProductId { get; set; }
        string Description { get; set; }
        int Quantity { get; set; }
    }
}