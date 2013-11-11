using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.UserAccountsPages
{
    public class UserAccountModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth (MM/dd/yyyy)")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Sex")]
        public SpringMvc.Models.POCO.PersonalData.Gender Sex { get; set; }
        [Display(Name = "Identity Card Number")]
        public string IdentityCardNumber { get; set; }
        [Display(Name = "PESEL")]
        [MinLength(11)]
        [StringLength(11)]
        public string PESEL { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
    }
}