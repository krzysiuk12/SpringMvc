using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.UserAccountsPages
{
    public class UserAccountModel
    {
        public UserAccount UserAccount { get; set; }
        public PersonalData PersonalData { get; set; }
        public Address Address { get; set; }

        public void ConnectUserAccountModelReferences()
        {
            UserAccount.PersonalData = PersonalData;
            PersonalData.Address = Address;
        }
    }
}