using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class Order
    {
        public enum OrderState { ORDERED, SENT, DELIVERED };

        public virtual long Id { get; set; }
        public virtual IList<OrderEntry> OrderEntries { get; set; }
        public virtual DateTime SentDate { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual DateTime DeliveryDate { get; set; }
        public virtual OrderState Status { get; set; }
        public virtual UserAccount User { get; set; }
    }
}