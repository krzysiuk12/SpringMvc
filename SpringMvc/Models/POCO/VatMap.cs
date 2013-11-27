using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class VatMap
    {
        public virtual long Id { get; set; }
        public virtual Decimal Value { get; set; }
    }
}