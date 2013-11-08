using System;
using System.Collections.Generic;
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

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }

        public virtual DateTime LastPasswordChangedDate { get; set; }

        public virtual DateTime LastSuccessfulSignInDate { get; set; }

        public virtual DateTime ValidFrom { get; set; }

        public virtual DateTime ValidTo { get; set; }

        public virtual Status AccountStatus { get; set; }

        public virtual PersonalData PersonalData { get; set; }
        #endregion
    }
}