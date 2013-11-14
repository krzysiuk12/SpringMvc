﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class BookType
    {
        public virtual long Id { get; set; }
        public virtual long CategoryId { get; set; }
        public virtual long QuantityMapId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Authors { get; set; }
        public virtual int Price { get; set; }
    }
}