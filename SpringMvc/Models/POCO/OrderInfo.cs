using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class OrderInfo
    {
        long OrderID {get; set;}
        long ClientID { get; set; }
        int NumberOfProducts { get; set;}
        string PurchaserName { get; set;}
        
    }
}