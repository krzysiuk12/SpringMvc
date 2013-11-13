using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class Order
    {
        enum OrderState { Ordered, InProgress, Paid, Finished };

        public virtual long Id { get; set; }
        public virtual long CustomerID { get; set; }
        public virtual Dictionary<long, long> OrderEntries { get; set; }
        public virtual DateTime SentDate { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual DateTime FinishedDate { get; set; }
        public virtual OrderState status { get; set; }
    }
}