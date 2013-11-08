using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Sample
{
    public class Address
    {
        #region Constructors
        public Address()
        {
        }

        public Address(string street, string city, string postalCode, string country)
        {
            this.Street = street;
            this.City = city;
            this.PostalCode = postalCode;
            this.Country = country;
        }
        #endregion

        #region Properties
        public virtual long Id { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        #endregion
    }
}