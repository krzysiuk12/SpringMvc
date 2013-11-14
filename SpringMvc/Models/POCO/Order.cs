using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class Order
    {
        public enum OrderState { Ordered, InProgress, Paid, Finished };

        public virtual long Id { get; set; }
        public virtual long CustomerID { get; set; }
        public virtual IEnumerable<OrderEntry> OrderEntries { get; set; }
        public virtual DateTime SentDate { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual DateTime FinishedDate { get; set; }
        public virtual OrderState Status { get; set; }
    }
}