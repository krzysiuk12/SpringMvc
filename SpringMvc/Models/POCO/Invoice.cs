using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class Invoice
    {
        public virtual long Id { get; set; }
        public virtual long Counter { get; set; }
        public virtual Decimal TotalValue { get; set; }
        public virtual VatMap Vat { get; set; }
        public virtual Order Order { get; set; }
    }
}