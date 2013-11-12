using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class BookTypeDetails
    {
        public virtual long Id { get; set; }
        public virtual int Quantity { get; set; }
    }
}