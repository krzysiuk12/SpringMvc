using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class Category
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
    }
}