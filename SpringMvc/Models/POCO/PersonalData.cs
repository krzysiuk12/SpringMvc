using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class PersonalData
    {
        #region Gender (enum)
        public enum Gender
        {
            MALE,
            FEMALE
        }
        #endregion

        #region Constructors
        public PersonalData()
        {
        }
        #endregion

        #region Properties
        public virtual long Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public virtual string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public virtual string MiddleName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }
        
        [Required]
        [Display(Name = "Date Of Birth")]
        public virtual DateTime DateOfBirth { get; set; }
        public virtual Gender Sex { get; set; }
        
        [Display(Name = "Identity Card Number")]
        public virtual string IdentityCardNumber { get; set; }
        
        [Required]
        [Display(Name = "PESEL")]
        [MinLength(11)]
        [StringLength(11)]
        public virtual string PESEL { get; set; }
        
        [Display(Name = "Phone Number")]
        public virtual string PhoneNumber { get; set; }
        
        public virtual Address Address { get; set; }
        #endregion
    }
}