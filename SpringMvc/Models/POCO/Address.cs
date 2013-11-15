using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
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
        
        [Required]
        [Display(Name = "Street")]
        public virtual string Street { get; set; }

        [Required]
        [Display(Name = "City")]
        public virtual string City { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public virtual string PostalCode { get; set; }

        [Required]
        [Display(Name = "Country")]
        public virtual string Country { get; set; }
        #endregion
    }
}