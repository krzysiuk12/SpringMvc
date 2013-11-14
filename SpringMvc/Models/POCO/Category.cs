using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Iesi.Collections;

namespace SpringMvc.Models.POCO
{
    public class Category
    {
        public virtual long Id { get; set; }
        public virtual String Name { get; set; }
    }
}