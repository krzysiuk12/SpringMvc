using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.ShipmentPages
{
    public class OrderEntryDetails
    {
        public virtual BookType Book { get; set; }
        public virtual OrderEntry OrderEntry { get; set; }
    }
}