using System;
using System.Collections.Generic;
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
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual Gender Sex { get; set; }
        public virtual string IdentityCardNumber { get; set; }
        public virtual string PESEL { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual Address Address { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        #endregion
    }
}