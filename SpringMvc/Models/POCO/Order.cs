using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class Order
    {
        public enum OrderState { ORDERED, SENT, DELIVERED };

        public virtual long Id { get; set; }

        [Display(Name = "Order Entries")]
        public virtual IList<OrderEntry> OrderEntries { get; set; }

        [Display(Name = "Sent Date")]
        public virtual DateTime SentDate { get; set; }

        [Display(Name = "Order Date")]
        public virtual DateTime OrderDate { get; set; }

        [Display(Name = "Delivery Date")]
        public virtual DateTime DeliveryDate { get; set; }
        
        [Display(Name = "Status")]
        public virtual OrderState Status { get; set; }

        [Display(Name = "User Account")]
        public virtual UserAccount User { get; set; }

        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            if (order == null)
                return false;
            return order.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}