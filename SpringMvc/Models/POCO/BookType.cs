using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class BookType
    {
        public virtual long Id { get; set; }
        public virtual Category Category { get; set; }
        public virtual QuantityMap QuantityMap { get; set; }
        public virtual string Title { get; set; }
        public virtual string Authors { get; set; }
        public virtual Decimal Price { get; set; }
        public virtual BookImage Image { get; set; }
    }
}