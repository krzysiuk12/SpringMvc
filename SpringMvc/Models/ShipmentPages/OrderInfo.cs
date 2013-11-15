using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;


namespace SpringMvc.Models.ShipmentPages
{
    public class OrderInfo
    {
        public virtual long OrderId { get; set; }
        public virtual long ClientId { get; set; }
        public virtual string PurchaserName { get; set; }
    }
}