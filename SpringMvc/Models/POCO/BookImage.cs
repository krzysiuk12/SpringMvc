using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class BookImage
    {
        public virtual long Id { get; set; }
        public virtual String URL { get; set; }
    }
}