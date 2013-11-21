using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.POCO
{
    public class UserAccount
    {
        #region Status (enum)
        public enum Status
        {
            ACTIVE,
            LOCKED_OUT,
            OFF,
            EXPIRED,
            REMOVED
        };
        #endregion

        #region Constructors
        public UserAccount()
        {
        }
        #endregion

        #region Properties
        public virtual long Id { get; set; }

        [Display(Name = "Login")]
        public virtual string Login { get; set; }

        [Display(Name = "Password")]
        public virtual string Password { get; set; }

        [Display(Name = "Email")]
        public virtual string Email { get; set; }

        [Display(Name = "Last Password Changed Date")]
        public virtual DateTime LastPasswordChangedDate { get; set; }

        [Display(Name = "Last Successful Sign In Date")]
        public virtual DateTime LastSuccessfulSignInDate { get; set; }

        [Display(Name = "Valid From")]
        public virtual DateTime ValidFrom { get; set; }

        [Display(Name = "Valid To")]
        public virtual DateTime ValidTo { get; set; }

        [Display(Name = "Account Status")]
        public virtual Status AccountStatus { get; set; }

        public virtual PersonalData PersonalData { get; set; }
        #endregion
    }
}