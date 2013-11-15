using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class OrderEntry
    {
        public virtual long Id { get; set; }
        public virtual BookType BookType { get; set; }
        public virtual Order Order { get; set; }
        public virtual int Amount { get; set; }
        public virtual Decimal Price { get; set; }
    }
}