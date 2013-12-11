using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        
        [DataType(DataType.Currency)]
        public virtual Decimal Price { get; set; }
        
        public virtual BookImage Image { get; set; }

        public override bool Equals(object obj)
        {
            BookType type = obj as BookType;
            if (type == null)
                return false;
            return String.Compare(type.Title, this.Title) == 0 && type.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}