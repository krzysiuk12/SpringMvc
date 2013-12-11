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

        public override bool Equals(object obj)
        {
            Category cat = obj as Category;
            if (cat == null)
                return false;
            return cat.Id == this.Id && String.Compare(Name, cat.Name) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}